
using System.Collections.Generic;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class CourseListViewModel
    /// Write your documentation here
    /// </summary>
    public class AddLecturerCourseListViewModel
    {
        public List<AddLecturerCourseListItemViewModel> CourseListItems { get; set; }

        #region constructor
        public AddLecturerCourseListViewModel()
        {

        }
        #endregion
    }
}