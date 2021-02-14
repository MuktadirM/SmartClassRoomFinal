using Microsoft.AspNet.Identity;
using SmartClassRoom.Domain.Exceptions;
using SmartClassRoom.Domain.Models.Core;
using System;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services.AuthenticationServices
{
    /// <summary>
    /// Class AuthenticationService
    /// Write your documentation here
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        #region constructor
        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }
        #endregion

        public async Task<Account> Login(string email, string password)
        {
            User user = await _accountService.GetByEmail(email);

            if (user == null) {
                throw new UserNotFoundException(email);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(user.Password, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(email, password);
            }

            Account account = new Account {
                User = user,
            };

            return account;
        }

        public async Task<RegistrationResult> Register(string confirmPassword, User user)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (user.Password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            User emailAccount = await _accountService.GetByEmail(user.Email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }
            if (result == RegistrationResult.Success) {
                User user1 = new User
                {
                    Email = user.Email,
                    Password = _passwordHasher.HashPassword(user.Password),
                    Type = 2,
                    CreatedAt = DateTime.Now,
                };
            
            }

            return result;
        }
    }
}