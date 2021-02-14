using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using Presentation.WPF.State.Authenticators;
using Presentation.WPF.State.Navigators;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System.Windows;
using System.Windows.Input;

namespace Presentation.WPF.ViewModels.Common
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        
        public User User { get=> _authenticator.CurrentAccount.User;
            set { User = value; }
        } 

        public ICommand UpdatePassword { get; set; }
        public ICommand UpdateProfile { get; set; }

        public string CurrentPass { get; set; } = "";
        public string NewPass { get; set; } = "";

        public ProfileViewModel(IAccountService accountService, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _accountService = accountService;

            UpdatePassword = new RelayACommand(UpdatePass);
            UpdateProfile = new RelayACommand(UpdateUser);

            _renavigator = renavigator;
        }


        private void UpdatePass() {
            _accountService.UpdatePassword(User,CurrentPass,NewPass).ContinueWith(task=> {
                if (task.Exception != null) {
                    MessageBox.Show("Sorry Network Fail","Database Error");
                    return;
                }
                if (task.Result == UpdateResult.Success) {
                    MessageBox.Show("Password Updated", "Success");
                    _authenticator.Logout();
                    _renavigator.Renavigate();
                }
                if (task.Result == UpdateResult.PassNotMatch) {
                    MessageBox.Show("Password Not Match", "Not Match");
                }

                if (task.Result == UpdateResult.PassEmpty) {
                    MessageBox.Show("Password Field Can not Empty", "Empty");
                }

            });
        }

        private void UpdateUser() {
            _accountService.Update(User.Id, User).ContinueWith(task =>
            {
                if (task.Exception != null) {
                    MessageBox.Show("Sorry Profile Cant be updated","Error");
                    return;
                }
                MessageBox.Show("Profile updated", "Success");
            });
            
        }



    }
}
