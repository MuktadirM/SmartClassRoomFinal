
using DataAccessLayer.Services.Common;
using Microsoft.EntityFrameworkCore;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class AttendanceService
    /// Write your documentation here
    /// </summary>
    public class AttendanceService : IAttendanceService
    {
        private readonly DatabaseContextFactory _contextFactory;
        private readonly NonQueryDataService<Attendance> _nonQueryDataService;

        #region constructor
        public AttendanceService(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Attendance>(_contextFactory);

        }
        #endregion
        public Task<Attendance> Create(Attendance entity)
        {
            return _nonQueryDataService.Create(entity);
        }

        public Task<bool> Delete(int id)
        {
            return _nonQueryDataService.Delete(id);
        }

        public async Task<IEnumerable<Attendance>> GetAll()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();

            IEnumerable<Attendance> attendances = await context.Attendances
                .Include(a=>a.Registration)
                .Include(a=>a.Registration.Student)
                .Include(a => a.Registration.Section.Course)
                .ToListAsync();
            return attendances;
        }

        public async Task<IEnumerable<Attendance>> GetBySection(List<int> sections)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            List<Attendance> attendances = new List<Attendance>();
            foreach (var section in sections) {
                IEnumerable<Attendance> atns = await context.Attendances.Where(a=>a.AttendProcessId == section).ToListAsync();
                attendances.AddRange(atns);
            }
            return attendances;
        }

        public async Task<Attendance> GetOne(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            var attendance = await context.Set<Attendance>().Where(a=>a.AttendProcessId==id).FirstOrDefaultAsync();
            return attendance;
        }

        public async Task<Attendance> TakeAttendance(Student student, Attendance type)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            AttendProcess attend = context.AttendenceHistories.Where(a => a.AttendProcessId == type.AttendProcessId).FirstOrDefault();

            attend.LastUpdated = DateTime.Now;

            var attenProcess = context.AttendenceHistories.Update(attend);

            Attendance atn = new Attendance {
                StudentId = student.Id,
                AttendProcessId = type.AttendProcessId,
                AttendanceType = type.AttendanceType,
                Time = DateTime.Now,
                CourseId = type.CourseId,
                LecturerId = type.LecturerId,
                CreatedAt = DateTime.Now,
                CreatedBy = type.CreatedBy,
                LastUpdated = DateTime.Now,
                IsActive = true,
                RegistrationId = type.RegistrationId,
            };

            var aa = await context.Set<Attendance>().AddAsync(atn);
            await context.SaveChangesAsync();

            return aa.Entity;
        }

        public Task<Attendance> Update(int id, Attendance entity)
        {
            return _nonQueryDataService.Update(id, entity);
        }

        public async Task<Attendance> UpdateAttendanceOnly(Attendance latest)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            var attendance = await context.Set<Attendance>().Where(a => a.Id == latest.Id).FirstOrDefaultAsync();
            attendance.AttendanceType = latest.AttendanceType;
            attendance.LastUpdated = latest.LastUpdated;
            return await _nonQueryDataService.Update(attendance.Id, attendance);
        }
    }
}