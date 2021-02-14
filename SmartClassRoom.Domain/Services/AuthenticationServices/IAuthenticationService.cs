using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
    }

    public interface IAuthenticationService
    {
        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="confirmPassword">The user's confirmed password.</param>
        /// <param name="user">User data contains user password and other info</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> Register(string confirmPassword, User user);

        /// <summary>
        /// Get an account for a user's credentials.
        /// </summary>
        /// <param name="email">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The account for the user.</returns>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task<Account> Login(string email, string password);
    }
}
