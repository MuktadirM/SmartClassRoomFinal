
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services.AuthenticationServices;
using System;
using System.Threading.Tasks;

namespace Presentation.WPF.State.Authenticators
{
    /// <summary>
    /// Interface IAuthenticator 
    /// Write your documentation here 
    /// </summary>
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="confirmPassword">The user's confirmed password.</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> Register(string email, string password, string confirmPassword);

        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task Login(string email, string password);

        void Logout();
    }
}
