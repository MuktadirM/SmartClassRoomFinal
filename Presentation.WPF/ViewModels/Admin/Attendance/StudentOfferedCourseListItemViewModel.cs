
using Presentation.WPF.Commands.Callbcks;
using System;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class StudentOfferedCourseListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentOfferedCourseListItemViewModel 
    {
        public int CourseId { get; set; }
        public int SectionId { get; set; }
        public string CourseName { get; set; }
        public string LecturerName { get; set; }
        public bool IsSelected { get; set; }

        public bool IsRemove { get; set; }

        public StudentOfferedCourseListItemViewModel()
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #region constructor

        #endregion




    }
}