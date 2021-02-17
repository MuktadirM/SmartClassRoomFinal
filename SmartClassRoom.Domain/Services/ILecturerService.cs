
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using SmartClassRoom.Domain.Services.AuthenticationServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    /// <summary>
    /// Interface ILecturerService 
    /// Write your documentation here 
    /// </summary>
    public interface ILecturerService : IDataService<Lecturer>
    {
        public enum LecturerRegistrationResult {
            Success,
            PasswordsDoNotMatch,
            EmailAlreadyExists,
            ZeroCourseFound
        }

        /// <summary>
        /// <paramref name="user">Every lecturer is an user </paramref>
        /// <paramref name="lecturer">Lecturer aditional data </paramref>
        /// <paramref name="courses">Lectuerer must have one or more courses </paramref>
        /// </summary>
        public Task<LecturerRegistrationResult> CreateLecturer(Lecturer lecturer, List<Course> courses);

        public Task<Lecturer> GetAllData(int id);

    }
}
