
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartClassRoom.Domain.Models;
using System.Threading.Tasks;

namespace DataAccessLayer.Services.Common
{
    /// <summary>
    /// Class NonQueryDataService
    /// Write your documentation here
    /// </summary>
    public class NonQueryDataService<T> where T : DomainObject
    {
        private readonly DatabaseContextFactory _contextFactory;

        #region constructor
        public NonQueryDataService(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        #endregion

        public async Task<T> Create(T entity)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (DatabaseContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }
    }
}