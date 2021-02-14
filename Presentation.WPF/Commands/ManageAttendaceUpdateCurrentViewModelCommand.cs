using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace Presentation.WPF.Commands
{
    /// <summary>
    /// Class ManageAttendaceUpdateCurrentViewModelCommand
    /// Write your documentation here
    /// </summary>
    public class ManageAttendaceUpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IManageAttendanceViewModelFactory _viewModelFactory;

        #region constructor
        public ManageAttendaceUpdateCurrentViewModelCommand(INavigator navigator, IManageAttendanceViewModelFactory viewModelFactory)
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
            if (parameter is MAViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}