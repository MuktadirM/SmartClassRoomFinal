
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace Presentation.WPF.Commands
{
    /// <summary>
    /// Class UpdateCourseViewModelCommand
    /// Write your documentation here
    /// </summary>
    public class UpdateCourseViewModelCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;
        private readonly INavigator _navigator;
        private readonly ICoursesViewModelFactory _viewModelFactory;

        #region constructor
        public UpdateCourseViewModelCommand(INavigator navigator, ICoursesViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }
        #endregion

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is CViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}