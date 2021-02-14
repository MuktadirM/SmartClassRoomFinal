using System;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class LecturerListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class CourseListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string CourseCode { get; set; }
        public int StudentCount { get; set; }
        public DateTime JoinDate { get; set; }
        public string Initials { get; set; }
        public bool IsSelected { get; set; }
        public string CoursePictureRGB { get; set; }

        public ICommand UpdateSelectedItem { get; set; }
        #region constructor

        #endregion

    }
}