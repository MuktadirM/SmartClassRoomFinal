using Presentation.ViewModels;
using Presentation.WPF.Commands;
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Factories;
using SmartClassRoom.Domain.Services.CourseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    public class MCourseViewModel : BaseViewModel
    {
        private readonly INavigator _navigator;
        private readonly ICoursesViewModelFactory _viewModelFactory;

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MCourseViewModel(ICoursesViewModelFactory coursesViewModelFactory)
        {
            _viewModelFactory = coursesViewModelFactory;

            _navigator = new Navigator();

            _navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCourseViewModelCommand(_navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(CViewType.Courses);

        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
