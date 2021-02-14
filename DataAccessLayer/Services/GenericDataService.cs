using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartClassRoom.Domain.Models;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class GenericDataService<T> : IDataService<T> where T: DomainObject
    {
        private readonly DatabaseContextFactory _contextFactory;

        public GenericDataService(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();

            EntityEntry<T> insertedValue =  await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            //No error handled here
            return insertedValue.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();

            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            //No error handled here
            return true;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();

            IEnumerable<T> entities = await context.Set<T>().ToListAsync();

            //No error handled here
            return entities;

        }

        public async Task<T> GetOne(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();

            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

            //No error handled here
            return entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();

            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            //No error handled here
            return entity;
        }
    }
}
