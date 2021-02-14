using Presentation.ViewModels;
using Presentation.WPF.Commands;
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Factories;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    public class MLecturerViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly ILectuerViewModelFactory _viewModelFactory;

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MLecturerViewModel(ILectuerViewModelFactory lectuerViewModelFactory)
        {
            _viewModelFactory = lectuerViewModelFactory;

            _navigator = new Navigator();

            _navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateLecturerViewModelCommand(_navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(LViewType.Lecturers);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
