using Presentation.ViewModels;
using System;

namespace Presentation.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        AdminHome,
        UserHome,
        AdminProfile,
        UserProfile,
        ManageLecturer,
        ManageCourse,
        ManageAttendance,
        ViewAttendance,
        TakeAttendance,
        RoomStatus,
        Logout,
        Register
    }

    public enum MAViewType { 
        AddStudent,
        AddFace,
        Students,
        ModifyAttendance
    }

    public enum CViewType { 
        AddCourse,
        Courses
    }

    public enum LViewType { 
        AddLecturer,
        Lecturers
    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
