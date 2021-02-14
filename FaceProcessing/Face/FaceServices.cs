using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using SmartClassRoom.Domain.Models.FaceProcessing;
using SmartClassRoom.Domain.Services.FaceServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceProcessing.Face
{
    public class FaceServices : IFaceServices
    {
        private readonly IFaceClientServices _faceClient;
        private const string groupId = "5fd688bf-f2e6-4171-b691-8a6539ecabd4";
        private const string RECOGNITION_MODEL = RecognitionModel.Recognition03;

        public FaceServices(IFaceClientServices faceClient)
        {
            _faceClient = faceClient;
        }

        public string GroupId() => groupId;

        public IFaceClient FaceClient() => _faceClient.FaceClicent();

        public async Task<IList<PersistedFace>> AddFacesToGroup(FaceProcess faces)
        {
            IList<PersistedFace> persistedFaces = new List<PersistedFace>();

            Person person = await _faceClient.FaceClicent().PersonGroupPerson.CreateAsync(personGroupId: groupId, name: faces.Matric);
            foreach (var similarImage in faces.Images) {
                using Stream fileStream = File.OpenRead(similarImage);
                PersistedFace face = await _faceClient.FaceClicent().PersonGroupPerson.AddFaceFromStreamAsync(groupId, person.PersonId,
                            fileStream, similarImage);
                persistedFaces.Add(face);
            }
            return persistedFaces;
        }

        public async Task CreateAttendanceGroup()
        {
            await _faceClient.FaceClicent().PersonGroup.CreateAsync(groupId, "FCVAC", recognitionModel: RECOGNITION_MODEL);
        }

        public async Task DeleteAttendanceGroup()
        {
            await _faceClient.FaceClicent().PersonGroup.DeleteAsync(groupId);
        }

        public async Task<IList<DetectedFace>> DetectFaceExtract(string image)
        {
            using Stream fileStream = File.OpenRead(image);

            return await _faceClient.FaceClicent().Face.DetectWithStreamAsync(fileStream,
                returnFaceAttributes: new List<FaceAttributeType?> { FaceAttributeType.Accessories, FaceAttributeType.Age,
                FaceAttributeType.Blur, FaceAttributeType.Emotion, FaceAttributeType.Exposure, FaceAttributeType.FacialHair,
                FaceAttributeType.Gender, FaceAttributeType.Glasses, FaceAttributeType.Hair, FaceAttributeType.HeadPose,
                FaceAttributeType.Makeup, FaceAttributeType.Noise, FaceAttributeType.Occlusion, FaceAttributeType.Smile },

                // We specify detection model 1 because we are retrieving attributes.
                detectionModel: DetectionModel.Detection01,
                recognitionModel: RECOGNITION_MODEL);
        }

        public async Task<IList<IdentifyResult>> IdentifyStudents(string image)
        {
            List<Guid?> sourceFaceIds = new List<Guid?>();

            List<DetectedFace> detectedFaces = await DetectFaceRecognize(_faceClient.FaceClicent(), image, RECOGNITION_MODEL);

            foreach (var detectedFace in detectedFaces) { sourceFaceIds.Add(detectedFace.FaceId.Value); }

            return await _faceClient.FaceClicent().Face.IdentifyAsync(sourceFaceIds, groupId);
        }

        public async Task<TrainingStatus> TrainAttendanceGroup()
        {
            Console.WriteLine($"Train person group {groupId}.");
            await _faceClient.FaceClicent().PersonGroup.TrainAsync(groupId);

            return await _faceClient.FaceClicent().PersonGroup.GetTrainingStatusAsync(groupId);
        }


        /// <summary>
        /// <param name="faceClient">Provide face client </param>
        /// <param name="url"></param>
        /// <param name="recognition_model"></param>
        /// <returns></returns>
        /// </summary>
        private static async Task<List<DetectedFace>> DetectFaceRecognize(IFaceClient faceClient, string url, string recognition_model)
        {
            using Stream fileStream = File.OpenRead(url);
            // Detect faces from image URL. Since only recognizing, use the recognition model 1.
            // We use detection model 2 because we are not retrieving attributes.
            IList<DetectedFace> detectedFaces = await faceClient.Face.DetectWithStreamAsync(fileStream, recognitionModel: recognition_model, detectionModel: DetectionModel.Detection02);
            Console.WriteLine($"{detectedFaces.Count} face(s) detected from image `{Path.GetFileName(url)}`");
            return detectedFaces.ToList();
        }
    }
}
