using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.WPF.ViewModels.Factories
{
    public interface IViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
