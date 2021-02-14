
using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;

namespace Presentation.WPF.ViewModels.Factories
{
    /// <summary>
    /// Interface IManageAttendanceViewModelFactory 
    /// Write your documentation here 
    /// </summary>
    public interface IManageAttendanceViewModelFactory
    {
        /// <summary>
        /// Write your documentation here
        /// </summary>
        BaseViewModel CreateViewModel(MAViewType viewType);
    }
}
