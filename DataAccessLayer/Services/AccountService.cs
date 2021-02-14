
using DataAccessLayer.Services.Common;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    /// <summary>
    /// Class AccountService
    /// Write your documentation here
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly DatabaseContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;
        private readonly IPasswordHasher _passwordHasher;

        #region constructor
        public AccountService(DatabaseContextFactory contextFactory,IPasswordHasher passwordHasher)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
            _passwordHasher = passwordHasher;
        }
        #endregion
        public async Task<User> Create(User entity)
        {
            string hashedPassword = _passwordHasher.HashPassword(entity.Password);
            entity.Password = hashedPassword;
            entity.IsActive = true;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public Task<Account> GetAccountById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            IEnumerable<User> entities = await context.Users.ToListAsync();

            return entities;
        }

        public async Task<User> GetByEmail(string email)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            User entity = await context.Users.FirstOrDefaultAsync(u=>u.Email == email);

            return entity;
        }

        public async Task<User> GetOne(int id)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            User entity = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

            return entity;
        }

        public async Task<User> Update(int id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async  Task<UpdateResult> UpdatePassword(User user,string current,string updated) {

            UpdateResult result = UpdateResult.Success;

            if (string.IsNullOrEmpty(current) || string.IsNullOrEmpty(updated)) {
                result = UpdateResult.PassEmpty;
                return result;
            }
            PasswordVerificationResult passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user.Password,current);

            if (passwordVerificationResult != PasswordVerificationResult.Success) {
                result = UpdateResult.PassNotMatch;
                return result;
            }
            if (result == UpdateResult.Success) {
                user.Password = _passwordHasher.HashPassword(updated);
                await Update(user.Id, user);
            }
            return result;
        }
    }
}