using Presentation.ViewModels;
using System;

namespace Presentation.WPF.State.Navigators
{
    public class Navigator : INavigator
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
