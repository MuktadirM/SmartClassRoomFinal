
using System;
using System.Collections.Generic;

namespace Presentation.UsersV.ViewModels.DesignTime
{
    /// <summary>
    /// Class AttendanceListDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class AttendanceListDesignViewModel : AttendanceListViewModel
    {
        public static AttendanceListDesignViewModel Instance => new AttendanceListDesignViewModel();

        #region constructor
        public AttendanceListDesignViewModel() {
            Items = new List<AttendanceListItemViewModel> { 
                new AttendanceListItemViewModel{
                    Name = "Monibur Rahman",
                    LastTakenAt = DateTime.UtcNow,
                    StudentId = 20,
                    Matric = 418986767,
                    CourseName = "Information System",
                    LecturerName = "Ali Akbor",
                    Type = AType.NotTaken,
                    Initials = "MR",
                    IsSelected = true,
                    ProfilePictureRGB = "FF00FF"
                },
                new AttendanceListItemViewModel{
                    Name = "F Rahman",
                    LastTakenAt = DateTime.UtcNow,
                    StudentId = 10,
                    Matric = 414586767,
                    CourseName = "Information System",
                    LecturerName = "Ali Akbor",
                    Type = AType.NotTaken,
                    Initials = "FR",
                    IsSelected = false,
                    ProfilePictureRGB = "AE22AE"
                    },
                new AttendanceListItemViewModel{
                    Name = "Ashique Rahman",
                    LastTakenAt = DateTime.UtcNow,
                    StudentId = 26,
                    Matric = 419986767,
                    CourseName = "Information System",
                    LecturerName = "Ali Akbor",
                    Type = AType.NotTaken,
                    Initials = "AR",
                    IsSelected = false,
                    ProfilePictureRGB = "AE90AE"
                    },
                new AttendanceListItemViewModel{
                    Name = "Ali Akbor",
                    LastTakenAt = DateTime.UtcNow,
                    StudentId = 22,
                    Matric = 418456767,
                    CourseName = "Information System",
                    LecturerName = "Ali Akbor",
                    Type = AType.NotTaken,
                    Initials = "AK",
                    IsSelected = false,
                    ProfilePictureRGB = "540754"
                    },
               new AttendanceListItemViewModel{
                    Name = "Salman Khan",
                    LastTakenAt = DateTime.UtcNow,
                    StudentId = 33,
                    Matric = 489898989,
                    CourseName = "Information System",
                    LecturerName = "Ali Akbor",
                    Type = AType.NotTaken,
                    Initials = "SK",
                    IsSelected = false,
                    ProfilePictureRGB = "540754"
                    }

            };
            
        }
        #endregion
    }
}