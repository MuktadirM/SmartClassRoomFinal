
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services.CourseServices
{
    /// <summary>
    /// Interface ICourseServices 
    /// Write your documentation here 
    /// </summary>
    public interface ICourseServices : IDataService<Course>
    {
        /// <summary>
        /// Write your documentation here
        /// </summary>
        public Task<Section> AddLecturer(Lecturer lecturer, Course course);

        public Task<IEnumerable<Section>> GetSections(Course course);

        public Task<IEnumerable<Section>> GetAllSections();

        public Task<IEnumerable<Registration>> GetCourseStudentsBySection(Section section);

        public Task<IEnumerable<Course>> CourseByLectuerer(int id);
    }
}
