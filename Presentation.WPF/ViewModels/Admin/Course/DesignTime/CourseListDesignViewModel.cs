using System;
using System.Collections.Generic;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class LecturerListViewModel
    /// Write your documentation here
    /// </summary>
    public class CourseListDesignViewModel : CourseListViewModel
    {
        public static CourseListDesignViewModel Instance => new CourseListDesignViewModel();

        #region constructor
        public CourseListDesignViewModel() {
            Items = new List<CourseListItemViewModel>
            {
                new CourseListItemViewModel{
                    Name = "Information System",
                    CourseCode ="IAS2233",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 100,
                    Initials = "IS",
                    IsSelected = false,
                    CoursePictureRGB = "FF00FF"
                    },
                new CourseListItemViewModel{
                    Name = "Software Engineering",
                    CourseCode ="IAS2773",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 100,
                    Initials = "SE",
                    IsSelected = false,
                    CoursePictureRGB = "AE22AE"
                    },
                new CourseListItemViewModel{
                    Name = "Computer Organization",
                    Faculty = "FCVAC",
                    CourseCode ="IAS1587",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 190,
                    Initials = "CO",
                    IsSelected = false,
                    CoursePictureRGB = "AE90AE"
                    },
                new CourseListItemViewModel{
                    Name = "Project Management",
                    Faculty = "FCVAC",
                    CourseCode ="IAS3355",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 60,
                    Initials = "PM",
                    IsSelected = false,
                    CoursePictureRGB = "540754"
                    }

            };
        }
        #endregion
    }
}