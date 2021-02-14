
using Presentation.WPF.State.Accounts;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services.AuthenticationServices;
using System;
using System.Threading.Tasks;

namespace Presentation.WPF.State.Authenticators
{
    /// <summary>
    /// Class Authenticator
    /// Write your documentation here
    /// </summary>
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        #region constructor
        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }
        #endregion

        public Account CurrentAccount
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }


        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task Login(string email, string password)
        {
            CurrentAccount = await _authenticationService.Login(email, password);
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string password, string confirmPassword)
        {
            User user = new User {Email = email,Password = password };

            return await _authenticationService.Register(confirmPassword,user);
        }
    }
}