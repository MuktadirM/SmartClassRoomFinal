
using DataAccessLayer.Services.Common;
using Microsoft.EntityFrameworkCore;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class RegistrationServices
    /// Write your documentation here
    /// </summary>
    public class RegistrationServices : IRegistrationService
    {
        private readonly IStudentService _studentService;
        private readonly DatabaseContextFactory _contextFactory;
        private readonly NonQueryDataService<Registration> _nonQueryDataService;

        #region constructor
        public RegistrationServices(
            DatabaseContextFactory contextFactory,
            IStudentService studentService)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Registration>(contextFactory);
            _studentService = studentService;
        }
        #endregion

        public async Task<Registration> Create(Registration entity)
        {
            entity.IsActive = true;
            entity.CreatedBy = 1;
            entity.CreatedAt = DateTime.Now;
            return await _nonQueryDataService.Create(entity);
        }

        public Task<bool> Delete(int id)
        {
            return _nonQueryDataService.Delete(id);
        }

        public async Task<IEnumerable<Registration>> GetAll()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<Registration> registrations = await context.Registrations.ToListAsync();
            return registrations;
        }

        public Task<Registration> GetOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task RegisterStudent(Student student, List<Section> sections)
        {
            var st = await _studentService.GetByMatric(student.Matric);
            if (st == null)
            {
                var newStudent = await _studentService.Create(student);
                student.Id = newStudent.Id;
            }
            else {
                student.Id = st.Id;
            }

            foreach (var section in sections) {
                Registration registration = new Registration { 
                    StudentId = student.Id,
                    SectionId = section.Id,
                    Intake = student.Sem,
                };

                await Create(registration);
            }


        }

        public async Task<IEnumerable<Registration>> RegistrationsByLecturer(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<Registration> registrations = await context.Registrations
                .Include(r=>r.Section)
                .Include(r=>r.Section.Course)
                .Include(r=>r.Section.AttendProcess)
                .Include(r=>r.Section.AttendProcess.Attendances)
                .ToListAsync();

                return registrations.Where(r=>r.Section.LecturerId == id);
        }

        public Task RemoveStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public Task<Registration> Update(int id, Registration entity)
        {
            throw new System.NotImplementedException();
        }
    }
}