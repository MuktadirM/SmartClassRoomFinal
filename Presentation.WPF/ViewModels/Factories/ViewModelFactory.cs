using Presentation.Admin.ViewModels;
using Presentation.UsersV.ViewModels;
using Presentation.ViewModels;
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Common;
using System;

namespace Presentation.WPF.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<AdminDashViewModel> _createAdminDashViewModel;
        private readonly CreateViewModel<UserDashboardViewModel> _createUserDashViewModel;
        private readonly CreateViewModel<ProfileViewModel> _createProfileViewModel;
        private readonly CreateViewModel<MLecturerViewModel> _createLecturerViewModel;
        private readonly CreateViewModel<MCourseViewModel> _createCourseViewModel;
        private readonly CreateViewModel<MAttendanceViewModel> _createMAttenViewModel;
        private readonly CreateViewModel<TakeAttendanceViewModel> _createTakeAttendanceViewModel;
        private readonly CreateViewModel<ViewAttendanceViewModel> _createViewAttendanceViewModel;
        private readonly CreateViewModel<RoomStatusViewModel> _createRoomStatusViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;
        private readonly CreateViewModel<LogoutViewModel> _createLogoutViewModel;

        public ViewModelFactory(CreateViewModel<AdminDashViewModel> createAdminDashViewModel,
            CreateViewModel<UserDashboardViewModel> createUserDashViewModel, 
            CreateViewModel<ProfileViewModel> createProfileViewModel, 
            CreateViewModel<MLecturerViewModel> createLecturerViewModel, 
            CreateViewModel<MCourseViewModel> createCourseViewModel, 
            CreateViewModel<MAttendanceViewModel> createMAttenViewModel, 
            CreateViewModel<TakeAttendanceViewModel> createTakeAttendanceViewModel, 
            CreateViewModel<ViewAttendanceViewModel> createViewAttendanceViewModel, 
            CreateViewModel<RoomStatusViewModel> createRoomStatusViewModel, 
            CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<RegisterViewModel> createRegisterViewModel, 
            CreateViewModel<LogoutViewModel> createLogoutViewModel)
        {
            _createAdminDashViewModel = createAdminDashViewModel;
            _createUserDashViewModel = createUserDashViewModel;
            _createProfileViewModel = createProfileViewModel;
            _createLecturerViewModel = createLecturerViewModel;
            _createCourseViewModel = createCourseViewModel;
            _createMAttenViewModel = createMAttenViewModel;
            _createTakeAttendanceViewModel = createTakeAttendanceViewModel;
            _createViewAttendanceViewModel = createViewAttendanceViewModel;
            _createRoomStatusViewModel = createRoomStatusViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createRegisterViewModel = createRegisterViewModel;
            _createLogoutViewModel = createLogoutViewModel;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.AdminHome => _createAdminDashViewModel(),
                ViewType.UserHome => _createUserDashViewModel(),
                ViewType.UserProfile => _createProfileViewModel(),
                ViewType.AdminProfile => _createProfileViewModel(),
                ViewType.ManageLecturer => _createLecturerViewModel(),
                ViewType.ManageCourse => _createCourseViewModel(),
                ViewType.ManageAttendance => _createMAttenViewModel(),
                ViewType.TakeAttendance => _createTakeAttendanceViewModel(),
                ViewType.ViewAttendance => _createViewAttendanceViewModel(),
                ViewType.RoomStatus => _createRoomStatusViewModel(),
                ViewType.Login => _createLoginViewModel(),
                ViewType.Register => _createRegisterViewModel(),
                ViewType.Logout => _createLogoutViewModel(),
                _ => throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType"),
            };
        }
    }
}
