
using System;
using System.Collections.Generic;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class LecturerListViewModel
    /// Write your documentation here
    /// </summary>
    public class LecturerListViewDesignModel : LecturerListViewModel
    {
        public static LecturerListViewDesignModel Instance => new LecturerListViewDesignModel();

        #region constructor
        public LecturerListViewDesignModel() {
            Items = new List<LecturerListItemViewModel>
            {
                new LecturerListItemViewModel{
                    Name = "Monibur Rahman",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 100,
                    CourseCount = 5,
                    Initials = "MR",
                    IsSelected = false,
                    ProfilePictureRGB = "FF00FF"
                    },
                new LecturerListItemViewModel{
                    Name = "F Rahman",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 100,
                    CourseCount = 5,
                    Initials = "FR",
                    IsSelected = false,
                    ProfilePictureRGB = "AE22AE"
                    },
                new LecturerListItemViewModel{
                    Name = "Ashique Rahman",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 190,
                    CourseCount = 5,
                    Initials = "AR",
                    IsSelected = false,
                    ProfilePictureRGB = "AE90AE"
                    },
                new LecturerListItemViewModel{
                    Name = "Ali Akbor",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    StudentCount = 100,
                    CourseCount = 5,
                    Initials = "AK",
                    IsSelected = false,
                    ProfilePictureRGB = "540754"
                    }

            };
            
        }
        #endregion
    }
}