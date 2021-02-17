
using System;

namespace Presentation.UsersV.ViewModels.DesignTime
{
    /// <summary>
    /// Class AttendanceListItemDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class AttendanceListItemDesignViewModel : AttendanceListItemViewModel
    {
        public static AttendanceListItemDesignViewModel Instance => new AttendanceListItemDesignViewModel();
        #region constructor
        public AttendanceListItemDesignViewModel() {
            StudentId = 20;
            Name = "Monibur Rahman";
            Matric = 418986767;
            CourseName = "Information System";
            LastTakenAt = DateTime.UtcNow;
            TakenAt = DateTime.UtcNow;
            ProfilePictureRGB = "FF00FF";
            LecturerName = "Ali Akbor";
            Type = AType.Absent;
            Initials = "MR";
            IsSelected = true;
        }
        #endregion
    }
}