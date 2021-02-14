using Presentation.ViewModels;
using Presentation.WPF.Commands;
using Presentation.WPF.State.Authenticators;
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Factories;
using SmartClassRoom.Domain.Models.Core;
using System.Windows.Input;

namespace Presentation.WPF.ViewModels.Common
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAuthenticator _authenticator;

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }
        public User User => GetUser();

        public bool IsLoggedIn => _authenticator.IsLoggedIn;

        public bool IsLecturer => !IsAdminCheck();
        public bool IsAdmin => IsAdminCheck();

        public MainViewModel(INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }


        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsLecturer));
            OnPropertyChanged(nameof(IsAdmin)); 
            OnPropertyChanged(nameof(User));
        }


        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;
            _authenticator.StateChanged -= Authenticator_StateChanged;

            base.Dispose();
        }

        private bool IsAdminCheck() {
            if (_authenticator.CurrentAccount != null) {
                return _authenticator.CurrentAccount.User.Type == 1;
            }
            return false; 
        }

        private User GetUser() {
            if (_authenticator.CurrentAccount != null)
            {
                return _authenticator.CurrentAccount.User;
            }
            return null;
        }

    }
}
