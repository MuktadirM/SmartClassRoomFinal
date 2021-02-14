using System;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class LecturerDesignListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentListItemDesignViewModel : StudentListItemViewModel
    {
        public static StudentListItemDesignViewModel Instance  => new StudentListItemDesignViewModel(); 

        #region constructor
        public StudentListItemDesignViewModel() {
            Name = "Monibur Rahman";
            Faculty = "FCVAC";
            Matric = "417343949";
            JoinDate = DateTime.UtcNow;
            ProfilePictureRGB = "FF00FF";
            FaceAdded = false;
            Initials = "MR";
            IsSelected = true;
        }
        #endregion
    }
}