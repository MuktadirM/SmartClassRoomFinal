using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;

namespace Presentation.WPF.ViewModels.Factories
{
    /// <summary>
    /// Interface ICoursesViewModelFactory 
    /// Write your documentation here 
    /// </summary>
    public interface ICoursesViewModelFactory
    {
        /// <summary>
        /// Write your documentation here
        /// </summary>
        BaseViewModel CreateViewModel(CViewType viewType);
    }
}
