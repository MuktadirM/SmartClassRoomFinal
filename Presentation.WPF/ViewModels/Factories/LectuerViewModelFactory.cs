
using Presentation.Admin.ViewModels;
using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;
using System;

namespace Presentation.WPF.ViewModels.Factories
{
    /// <summary>
    /// Class LectuerViewModelFactory
    /// Write your documentation here
    /// </summary>
    public class LectuerViewModelFactory : ILectuerViewModelFactory
    {
        private readonly CreateViewModel<LecturersViewModel> _lecturersViewModel;
        private readonly CreateViewModel<AddLectuerViewModel> _addLectuerViewModel;

        public LectuerViewModelFactory(
            CreateViewModel<LecturersViewModel> lecturersViewModel,
            CreateViewModel<AddLectuerViewModel> addLectuerViewModel)
        {
            _lecturersViewModel = lecturersViewModel;
            _addLectuerViewModel = addLectuerViewModel;
        }
        #region constructor
        #endregion
        public BaseViewModel CreateViewModel(LViewType viewType)
        {
            return viewType switch
            {
                LViewType.AddLecturer => _addLectuerViewModel(),
                LViewType.Lecturers => _lecturersViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType"),
            };
        }
    }
}