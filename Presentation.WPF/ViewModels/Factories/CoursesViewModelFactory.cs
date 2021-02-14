
using Presentation.Admin.ViewModels;
using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;
using System;

namespace Presentation.WPF.ViewModels.Factories
{
    /// <summary>
    /// Class CoursesViewModelFactory
    /// Write your documentation here
    /// </summary>
    public class CoursesViewModelFactory : ICoursesViewModelFactory
    {
        private readonly CreateViewModel<AddCourseViewModel> _addCourseViewModel;
        private readonly CreateViewModel<CoursesViewModel> _coursesViewModel;

        #region constructor
        public CoursesViewModelFactory(CreateViewModel<AddCourseViewModel> addCourseViewModel, CreateViewModel<CoursesViewModel> coursesViewModel)
        {
            _addCourseViewModel = addCourseViewModel;
            _coursesViewModel = coursesViewModel;
        }
        #endregion

        public BaseViewModel CreateViewModel(CViewType viewType)
        {
            return viewType switch
            {
                CViewType.AddCourse => _addCourseViewModel(),
                CViewType.Courses => _coursesViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType"),
            };
        }
    }
}