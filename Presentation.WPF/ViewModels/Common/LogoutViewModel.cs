using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using Presentation.WPF.State.Authenticators;
using Presentation.WPF.State.Navigators;
using SmartClassRoom.Domain.Services;
using System.Windows.Input;

namespace Presentation.WPF.ViewModels.Common
{
    public class LogoutViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigate;
        public ICommand Logout { get; set; }

        public LogoutViewModel(IAccountService accountService, IAuthenticator authenticator,IRenavigator renavigate) {
            _accountService = accountService;
            _authenticator = authenticator;
            _renavigate = renavigate;

            Logout = new RelayACommand(LogoutUser);
        }

        private void LogoutUser() {
            _authenticator.Logout();
            _renavigate.Renavigate();
        }




    }
}
