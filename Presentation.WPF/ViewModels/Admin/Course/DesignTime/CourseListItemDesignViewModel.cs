using System;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class LecturerListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class CourseListItemDesignViewModel : CourseListItemViewModel
    {
        public static CourseListItemDesignViewModel Instance => new CourseListItemDesignViewModel();

        #region constructor
        public CourseListItemDesignViewModel() {
            Name = "Information System";
            CourseCode = "IAS2233";
            Faculty = "FCVAC";
            JoinDate = DateTime.UtcNow;
            CoursePictureRGB = "FF00FF";
            StudentCount = 100;
            Initials = "IS";
            IsSelected = true;
        }
        #endregion

    }
}