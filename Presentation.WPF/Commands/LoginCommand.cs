
using Presentation.WPF.State.Authenticators;
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Common;
using SmartClassRoom.Domain.Exceptions;
using SmartClassRoom.Domain.Models.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Presentation.WPF.Commands
{
    /// <summary>
    /// Class LoginCommand
    /// Write your documentation here
    /// </summary>
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        private readonly IRenavigator _renavigatorUser;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator,IRenavigator renavigatorUser)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
            _renavigatorUser = renavigatorUser;

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;

            try
            {
                await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
                Account account = _authenticator.CurrentAccount;

                if (account.User.Type == 1)
                {
                    _renavigator.Renavigate();
                }
                else {

                    _renavigatorUser.Renavigate();
                }
                
            }
            catch (UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Username does not exist.";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Incorrect password.";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Login failed.";
            }
        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }

    }
}