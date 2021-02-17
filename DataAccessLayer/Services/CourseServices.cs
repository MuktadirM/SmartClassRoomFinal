
using DataAccessLayer.Services.Common;
using Microsoft.EntityFrameworkCore;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using SmartClassRoom.Domain.Services.CourseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class CourseServices
    /// Write your documentation here
    /// </summary>
    public class CourseServices : ICourseServices
    {
        private readonly DatabaseContextFactory _contextFactory;
        private readonly NonQueryDataService<Course> _nonQueryDataService;
        private readonly NonQueryDataService<Section> _nonQuerySectionData;

        #region constructor
        public CourseServices(DatabaseContextFactory contextFactory) {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Course>(contextFactory);
            _nonQuerySectionData = new NonQueryDataService<Section>(contextFactory);
        }
        #endregion

        public async Task<Section> AddLecturer(Lecturer lecturer, Course course)
        {
            AttendProcess attenProcess = new AttendProcess
            {
                LastUpdated = DateTime.Now,
                CreatedAt = DateTime.Now,
                CreatedBy = 1,
                IsActive = true,
            };

            Section section = new Section
            {
                CourseId = course.Id,
                LecturerId = lecturer.Id,
                CreatedAt = DateTime.Now,
                CreatedBy = 1,
                IsActive = true,
                AttendProcess = attenProcess,
            };

            return await _nonQuerySectionData.Create(section);
        }

        public async Task<Course> Create(Course entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<Course> entities = await context.Courses
                .Include(c=>c.Sections)
                .ToListAsync();

            return entities;
        }

        public async Task<IEnumerable<Section>> GetAllSections()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<Section> sections = await context.Sections
                .Include(s => s.Course)
                .Include(s => s.Lecturer.User)
                .Include(s => s.AttendProcess)
                .ToListAsync();
            return sections;
        }

        public async Task<IEnumerable<Registration>> GetCourseStudentsBySection(Section section)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<Registration> courseRegisterd = await context.Set<Registration>()
                .Where(s => s.SectionId == section.Id)
                .Include(s => s.Student)
                .Include(s=>s.Section.AttendProcess)
                .ToListAsync();

            return courseRegisterd;
        }

        public async Task<Course> GetOne(int id)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                Course entity = await context.Courses
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Section>> GetSections(Course course)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Section> entities = await context.Sections.Where(s=> s.CourseId == course.Id).ToListAsync();

                return entities;
            }
        }

        public async Task<Course> Update(int id, Course entity)
        {
            return await _nonQueryDataService.Update(id,entity);
        }

        public async Task<IEnumerable<Registration>> RegistrationsByLecturer(int id) {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<Registration> courseRegisterd = await context.Set<Registration>()
                .Where(s => s.Section.LecturerId == id)
                .Include(s => s.Student)
                .Include(s => s.Section.AttendProcess)
                .Include(s =>s.Section.AttendProcess.Attendances)
                .ToListAsync();
            return courseRegisterd;
        }

        public async Task<IEnumerable<Course>> CourseByLectuerer(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<Section> sections = await context.Sections
                .Where(s=>s.LecturerId == id)
                .Include(s=>s.Course)
                .ToListAsync();
            List<Course> courses = new List<Course>();
            foreach (var section in sections) {
                var exist = courses.Find(c=>c.Id == section.CourseId);
                if (exist == null) {
                    courses.Add(section.Course);
                }
            }
            return courses;
        }


    }
}