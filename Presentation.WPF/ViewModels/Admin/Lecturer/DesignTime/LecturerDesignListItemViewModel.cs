
using System;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class LecturerDesignListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class LecturerDesignListItemViewModel : LecturerListItemViewModel
    {
        public static LecturerDesignListItemViewModel Instance  => new LecturerDesignListItemViewModel(); 

        #region constructor
        public LecturerDesignListItemViewModel() {
            Name = "Monibur Rahman";
            Faculty = "FCVAC";
            JoinDate = DateTime.UtcNow;
            ProfilePictureRGB = "FF00FF";
            StudentCount = 100;
            CourseCount = 5;
            Initials = "MR";
            IsSelected = true;
        }
        #endregion
    }
}