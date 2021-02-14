using Presentation.ViewModels;
using Presentation.WPF.Commands;
using Presentation.WPF.State.Authenticators;
using Presentation.WPF.State.Navigators;

using System.Windows.Input;

namespace Presentation.WPF.ViewModels.Common
{
   public class LoginViewModel : BaseViewModel
    {
		private string _username = "admin@gmail.com";
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		private string _password="123Qwe&&";
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
				OnPropertyChanged(nameof(CanLogin));
			}
		}

		public bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

		public MessageViewModel ErrorMessageViewModel { get; }

		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}

		public ICommand LoginCommand { get; }

		public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator loginRenavigator2)
		{
			ErrorMessageViewModel = new MessageViewModel();

			LoginCommand = new LoginCommand(this, authenticator, loginRenavigator,loginRenavigator2);
		}

		public override void Dispose()
		{
			ErrorMessageViewModel.Dispose();

			base.Dispose();
		}
	}
}
