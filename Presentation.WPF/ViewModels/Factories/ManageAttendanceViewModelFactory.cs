
using Presentation.Admin.ViewModels;
using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;
using System;

namespace Presentation.WPF.ViewModels.Factories
{
    /// <summary>
    /// Class ManageAttendanceViewModelFactory
    /// Write your documentation here
    /// </summary>
    public class ManageAttendanceViewModelFactory : IManageAttendanceViewModelFactory
    {
        private readonly CreateViewModel<AddStudentViewModel> _createStudentViewModel;
        private readonly CreateViewModel<AddFaceViewModel> _createFaceViewModel;
        private readonly CreateViewModel<ModifyAttendanceViewModel> _createModifyViewModel;
        private readonly CreateViewModel<StudentsViewModel> _createStudentsViewModel;

        #region constructor
        public ManageAttendanceViewModelFactory(
            CreateViewModel<AddStudentViewModel> createStudentViewModel,
            CreateViewModel<AddFaceViewModel> createFaceViewModel,
            CreateViewModel<ModifyAttendanceViewModel> createModifyViewModel, 
            CreateViewModel<StudentsViewModel> createStudentsViewModel)
        {
            _createStudentViewModel = createStudentViewModel;
            _createFaceViewModel = createFaceViewModel;
            _createModifyViewModel = createModifyViewModel;
            _createStudentsViewModel = createStudentsViewModel;
        }
        #endregion

        public BaseViewModel CreateViewModel(MAViewType viewType)
        {
            return viewType switch
            {
                MAViewType.AddStudent => _createStudentViewModel(),
                MAViewType.AddFace => _createFaceViewModel(),
                MAViewType.ModifyAttendance => _createModifyViewModel(),
                MAViewType.Students =>_createStudentsViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType"),
            };
        }
    }
}