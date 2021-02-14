
using Presentation.WPF.ViewModels.Common;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class CourseListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class AddStudentCourseListItemViewModel : CourseListItemViewModel
    {
        public int SectionId { get; set; }
        public string LecturerName { get; set; }
        public int ProcessId { get; set; }

        #region constructor
        #endregion
    }
}