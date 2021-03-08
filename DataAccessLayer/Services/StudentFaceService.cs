
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.FaceProcessing;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using SmartClassRoom.Domain.Services.FaceServices;
using SmartClassRoom.Domain.Services.StudentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class StudentFaceService
    /// Write your documentation here
    /// </summary>
    public class StudentFaceService : IStudentFaceService
    {
        private readonly IFaceServices _faceService;
        private readonly IStudentService _studentService;
        private readonly ICourseServices _courseServices;

        #region public constructor
        public StudentFaceService(IFaceServices faceService, IStudentService studentService,ICourseServices courseServices)
        {
            _faceService = faceService;
            _studentService = studentService;
            _courseServices = courseServices;
        }
        #endregion

        public async Task<bool> AddFace(FaceProcess faceProcess)
        {
            var result = true;

            //Student student = await _studentService.GetOne(faceProcess.Id);
            //student.FaceAdded = true;

            //await _studentService.Update(faceProcess.Id, student);

            try
            {
                await _faceService.AddFacesToGroup(faceProcess);
                Student student = await _studentService.GetOne(faceProcess.Id);
                student.FaceAdded = true;

                await _studentService.Update(faceProcess.Id, student);
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public async Task CreateAttendanceGroup()
        {
            await _faceService.CreateAttendanceGroup();
        }

        public async Task DeleteAttendanceGroup()
        {
           await _faceService.DeleteAttendanceGroup();
        }

        public async Task<IEnumerable<StudentFaceAttendance>> GetStudentFaceAttendances(string image,Section section)
        {
            int Count = 0;
            List<StudentFaceAttendance> studentFaceAttendances = new List<StudentFaceAttendance>();

            List<Person> people = new List<Person>();

            try
            {
                var identifyResults = await _faceService.IdentifyStudents(image);


                if (identifyResults.Count() > 0)
                {
                    foreach (var identifyResult in identifyResults)
                    {
                        Person person = await _faceService.FaceClient().PersonGroupPerson.GetAsync(_faceService.GroupId(), identifyResult.Candidates[0].PersonId);
                        people.Add(person);
                        Console.WriteLine($"Person '{person.Name}' is identified for face in: {image} - {identifyResult.FaceId}," +
                            $" confidence: {identifyResult.Candidates[0].Confidence}.");

                        studentFaceAttendances.Add(new StudentFaceAttendance
                        {
                            Matric = long.Parse(person.Name.Trim()),
                            ConfidanceLevel = Convert.ToInt32((identifyResult.Candidates[0].Confidence) * 100),
                        });

                    }

                    var identifyEmo = await _faceService.DetectFaceExtract(image);

                    foreach (var emotion in identifyEmo)
                    {
                        try
                        {
                            studentFaceAttendances.ElementAt(Count).EmotionType = GetEmotion(emotion);
                        }
                        catch
                        {
                            Console.WriteLine("Array out of bound here");
                        }
                        Count++;
                    }


                    var regiStudents = await _courseServices.GetCourseStudentsBySection(section);

                    //foreach (var stu in regiStudents) {
                    //    studentFaceAttendances.Add(new StudentFaceAttendance
                    //    {
                    //        Matric = stu.Student.Matric,
                    //        EmotionType = EmotionType.Neutral,
                    //        AttendanceType = AttendanceType.Present,
                    //        ConfidanceLevel = 90,
                    //    });
                    //}

                    foreach (var stu in regiStudents)
                    {
                        var stud = studentFaceAttendances.Find(st => st.Matric == stu.Student.Matric);
                        if (stud != null)
                        {
                            studentFaceAttendances.Remove(stud);
                            stud.AttendanceType = AttendanceType.Present;
                            studentFaceAttendances.Add(stud);
                        }
                        else
                        {
                            studentFaceAttendances.Add(new StudentFaceAttendance
                            {
                                Matric = stu.Student.Matric,
                                EmotionType = EmotionType.Undetected,
                                AttendanceType = AttendanceType.Undetected,
                                ConfidanceLevel = 0,
                            });
                        }
                    }
                }
            }
            catch {
                return studentFaceAttendances;
            }


            return studentFaceAttendances;
        }

        public async Task<TrainingStatus> TraningStatus()
        {
            return await _faceService.TrainAttendanceGroup();
        }

        private EmotionType GetEmotion(DetectedFace detected) {
            if (detected.FaceAttributes.Emotion.Anger > 70)
            {
                return EmotionType.Anger;
            }
            else if (detected.FaceAttributes.Emotion.Sadness > 70)
            {
                return EmotionType.Sad;
            }
            else if (detected.FaceAttributes.Emotion.Happiness > 70)
            {
                return EmotionType.Happy;
            }
            else if (detected.FaceAttributes.Emotion.Fear > 70)
            {
                return EmotionType.Fear;
            }
            else if (detected.FaceAttributes.Emotion.Disgust > 70)
            {
                return EmotionType.Disgust;
            }
            else if (detected.FaceAttributes.Emotion.Contempt > 70)
            {
                return EmotionType.Contempt;
            }
            else if (detected.FaceAttributes.Emotion.Neutral > 70) {
                return EmotionType.Neutral;
            }
            else return EmotionType.Unknown;
        }




    }
}