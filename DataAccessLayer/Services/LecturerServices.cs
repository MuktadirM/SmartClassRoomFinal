using DataAccessLayer.Services.Common;
using Microsoft.EntityFrameworkCore;
using SmartClassRoom.Domain.Models;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class LecturerServices
    /// Write your documentation here
    /// </summary>
    public class LecturerServices : ILecturerService
    {
        private readonly DatabaseContextFactory _contextFactory;
        private readonly NonQueryDataService<Lecturer> _nonQueryDataService;
        private readonly ICourseServices _courseServices;
        private readonly IAccountService _accountService;

        #region constructor
        public LecturerServices(
            DatabaseContextFactory contextFactory, 
            ICourseServices courseServices,
            IAccountService accountService
            )
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Lecturer>(contextFactory);
            _courseServices = courseServices;
            _accountService = accountService;
        }
        #endregion

        public Task<Lecturer> Create(Lecturer entity)
        {
            return _nonQueryDataService.Create(entity);
        }

        public async Task<ILecturerService.LecturerRegistrationResult> CreateLecturer(Lecturer lecturer, List<Course> courses)
        {
            ILecturerService.LecturerRegistrationResult result = ILecturerService.LecturerRegistrationResult.Success;
            using (DatabaseContext context = _contextFactory.CreateDbContext()) {
                User user1 = await _accountService.GetByEmail(lecturer.User.Email);
                if (user1 != null) {
                    result = ILecturerService.LecturerRegistrationResult.EmailAlreadyExists;
                }

                if (courses.Count <1) {
                    result = ILecturerService.LecturerRegistrationResult.ZeroCourseFound;
                }

                if (result == ILecturerService.LecturerRegistrationResult.Success) {
                    lecturer.User.Type = (int)UserType.Lecturer;
                   
                    User created = await _accountService.Create(lecturer.User);

                    Lecturer lecturerEntity = new Lecturer {UserId = created.Id,Faculty = lecturer.Faculty};
                    Lecturer lecturer1 = await Create(lecturerEntity);

                    foreach (var course in courses)
                    {
                        await _courseServices.AddLecturer(lecturer1, course);
                    }

                }
            }


                return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Lecturer>> GetAll()
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext()) {
                IEnumerable<Lecturer> entities = await context.Lecturers
                    .Include(l=>l.Sections)
                    .Include(a=>a.User)
                    .ToListAsync();

                return entities;
            }
        }

        public async Task<Lecturer> GetAllData(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            Lecturer lecturer = await context.Lecturers
                .Include(l=>l.Sections)
                .Include(l => l.User)
                .FirstOrDefaultAsync(l=>l.Id == id);
            return lecturer;
        }

        public async Task<Lecturer> GetOne(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            Lecturer entiry = await context.Lecturers.FirstOrDefaultAsync(l=>l.UserId == id);
            return entiry;
        }

        public Task<Lecturer> Update(int id, Lecturer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}