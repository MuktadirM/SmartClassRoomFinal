using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using SmartClassRoom.Domain.Models.FaceProcessing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services.FaceServices
{
    public interface IFaceServices
    {
        public string GroupId();
        public IFaceClient FaceClient();
        public Task CreateAttendanceGroup();
        public Task<IList<PersistedFace>> AddFacesToGroup(FaceProcess faces);
        public Task<TrainingStatus> TrainAttendanceGroup();
        public Task<IList<IdentifyResult>> IdentifyStudents(string image);
        public Task<IList<DetectedFace>> DetectFaceExtract(string image);
        public Task DeleteAttendanceGroup();
    }
}
