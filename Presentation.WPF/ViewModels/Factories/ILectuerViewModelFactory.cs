
using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;

namespace Presentation.WPF.ViewModels.Factories
{
    /// <summary>
    /// Interface ILectuerViewModelFactory 
    /// Write your documentation here 
    /// </summary>
    public interface ILectuerViewModelFactory
    {
        /// <summary>
        /// Write your documentation here
        /// </summary>
        BaseViewModel CreateViewModel(LViewType viewType);
    }
}
