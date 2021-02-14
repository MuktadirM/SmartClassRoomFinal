using System;
using System.Collections.Generic;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class LecturerListViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentListViewDesignModel : StudentListViewModel
    {
        public static StudentListViewDesignModel Instance => new StudentListViewDesignModel();

        #region constructor
        public StudentListViewDesignModel() {
            Items = new List<StudentListItemViewModel>
            {
                new StudentListItemViewModel{
                    Name = "Monibur Rahman",
                    Faculty = "FCVAC",
                    Matric = "4173002641",
                    FaceAdded = true,
                    JoinDate = DateTime.UtcNow,
                    Initials = "MR",
                    IsSelected = true,
                    ProfilePictureRGB = "FF00FF"
                    },
                new StudentListItemViewModel{
                    Name = "F Rahman",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    Matric = "4173006581",
                    FaceAdded = false,
                    Initials = "FR",
                    IsSelected = false,
                    ProfilePictureRGB = "AE22AE"
                    },
                new StudentListItemViewModel{
                    Name = "Ashique Rahman",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    Matric = "4173002641",
                    FaceAdded = true,
                    Initials = "AR",
                    IsSelected = false,
                    ProfilePictureRGB = "AE90AE"
                    },
                new StudentListItemViewModel{
                    Name = "Ali Akbor",
                    Faculty = "FCVAC",
                    JoinDate = DateTime.UtcNow,
                    Matric = "4173002654",
                    FaceAdded = false,
                    Initials = "AK",
                    IsSelected = false,
                    ProfilePictureRGB = "540754"
                    }

            };
            
        }
        #endregion

        public List<StudentListItemViewModel> NoFaceFound => Items.FindAll(e=>e.FaceAdded);
    }
}