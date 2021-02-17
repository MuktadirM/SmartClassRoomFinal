
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Core.Statistics;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class StatisticsDataServices
    /// Write your documentation here
    /// </summary>
    public class StatisticsDataServices : IStatisticsDataServices
    {
        private readonly IAccountService _accountService;
        private readonly IStudentService _studentService;
        private readonly ICourseServices _courseServices;
        private readonly ILecturerService _lecturerServices;
        private readonly IRegistrationService _registrationService;
        private readonly IAttendanceService _attendanceService;


        #region constructor
        public StatisticsDataServices(IAccountService accountService, 
            IStudentService studentService, ICourseServices courseServices, 
            ILecturerService lecturerServices, IRegistrationService registrationService,
            IAttendanceService attendanceService)
        {
            _accountService = accountService;
            _studentService = studentService;
            _courseServices = courseServices;
            _lecturerServices = lecturerServices;
            _registrationService = registrationService;
            _attendanceService = attendanceService;
        }
        #endregion


        public async Task<StatisticsData> GetAll()
        {
            var stastics = new StatisticsData();

            var users = await _accountService.GetAll();
            var courses = await _courseServices.GetAll();
            var lectuers = await _lecturerServices.GetAll();
            var students = await _studentService.GetAll();
            var registrations = await _registrationService.GetAll();
            var attendances =await _attendanceService.GetAll();
            var sections = await _courseServices.GetAllSections();

            stastics.Users = users.Count();
            stastics.Courses = courses.Count();
            stastics.Lecturers = lectuers.Count();
            stastics.Students = students.Count();
            stastics.Registrations = registrations.Count();
            stastics.StudentFaceAdded = students.Where(s=>s.FaceAdded == true).ToList().Count();
            stastics.Attendances = attendances.Count();
            int percent = (100 * (attendances.Where(at => at.AttendanceType == 1).ToList().Count()))/ stastics.Attendances;
            stastics.AttendancePercent = percent;
            stastics.LastUpdate = DateTime.Now;
            stastics.Sections = sections.Count();
            return stastics;
        }

        public async Task<IEnumerable<Course>> LecturerCourses(int id)
        {
            var lecturer = await _lecturerServices.GetOne(id);
            var courses = await _courseServices.CourseByLectuerer(lecturer.Id);
            return courses;
        }

        public async Task<LecturerStatisticsData> LecturerStatisticsData(int id)
        {
            int presentCount = 0;
            var lecturerStatisticsData = new LecturerStatisticsData();
            var lecturer = await _lecturerServices.GetOne(id);
            var registrations = await _registrationService.RegistrationsByLecturer(lecturer.Id);
            var courses = await _courseServices.CourseByLectuerer(lecturer.Id);

            lecturerStatisticsData.Courses = courses.Count();
            
            foreach (var registration in registrations) {
                var attends = registration.Section.AttendProcess.Attendances;
                lecturerStatisticsData.Attendances = attends.Count();
                presentCount += attends.Count(at=>at.AttendanceType == 1);
                lecturerStatisticsData.Students += 1;
                lecturerStatisticsData.LastUpdate = registration.Section.AttendProcess.LastUpdated;
            }
            lecturerStatisticsData.Courses = courses.Count();
            lecturerStatisticsData.AttendancePercent = (100 * presentCount) / lecturerStatisticsData.Attendances;

            return lecturerStatisticsData;
            
        }


    }
}