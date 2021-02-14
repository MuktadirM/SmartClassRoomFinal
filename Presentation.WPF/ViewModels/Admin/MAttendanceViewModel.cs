using Presentation.ViewModels;
using Presentation.WPF.Commands;
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    public class MAttendanceViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly IManageAttendanceViewModelFactory _viewModelFactory;

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }

        /// <summary>
        /// For indvidual navigation can't pass navigator as constructor parameter. Because it will refferance to default navigator
        /// </summary>
        /// <param name="viewModelFactory"></param>
        public MAttendanceViewModel(IManageAttendanceViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = new Navigator();

            _navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new ManageAttendaceUpdateCurrentViewModelCommand(_navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(MAViewType.Students);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }







    }
}
