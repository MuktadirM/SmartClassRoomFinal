
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.FaceProcessing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services.StudentServices
{
    /// <summary>
    /// Interface IStudentFaceService 
    /// Write your documentation here 
    /// </summary>
    public interface IStudentFaceService
    {
        /// <summary>
        /// Write your documentation here
        /// </summary>
        public Task CreateAttendanceGroup();
        public Task<bool> AddFace(FaceProcess faceProcess);
        public Task<TrainingStatus> TraningStatus();
        public Task<IEnumerable<StudentFaceAttendance>> GetStudentFaceAttendances(string image, Section section);
        public Task DeleteAttendanceGroup();
    }
}
