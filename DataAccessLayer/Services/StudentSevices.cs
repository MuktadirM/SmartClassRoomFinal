
using DataAccessLayer.Services.Common;
using Microsoft.EntityFrameworkCore;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class StudentSevices
    /// Write your documentation here
    /// </summary>
    public class StudentSevices : IStudentService
    {
        private readonly DatabaseContextFactory _contextFactory;
        private readonly NonQueryDataService<Student> _nonQueryDataService;

        public StudentSevices(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Student>(contextFactory);
        }


        #region constructor

        #endregion
        public Task<Student> Create(Student entity)
        {
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = 1;
            entity.FaceAdded = false;
            entity.UpdatedAt = DateTime.Now;

            return _nonQueryDataService.Create(entity);
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();

            IEnumerable<Student> students = await context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetByMatric(long matric)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            Student student = await context.Students.Where(st => st.Matric == matric).FirstOrDefaultAsync();
            return student;

        }

        public async Task<Student> GetOne(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            Student student = await context.Set<Student>().FirstOrDefaultAsync((e) => e.Id == id);
            return student;
        }

        public Task<Student> Update(int id, Student entity)
        {
            return _nonQueryDataService.Update(id,entity);
        }
    }
}