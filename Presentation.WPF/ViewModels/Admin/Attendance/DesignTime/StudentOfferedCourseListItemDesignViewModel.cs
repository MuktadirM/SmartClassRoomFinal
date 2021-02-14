
using Presentation.WPF.Commands.Callbcks;

namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class StudentOfferedCourseListItemDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentOfferedCourseListItemDesignViewModel : StudentOfferedCourseListItemViewModel
    {
        public static StudentOfferedCourseListItemDesignViewModel Instance => new StudentOfferedCourseListItemDesignViewModel();

        #region constructor
        public StudentOfferedCourseListItemDesignViewModel()
        {
            SectionId = 34;
            CourseId = 3;
            CourseName = "Information System";
            LecturerName = "Latifah Abdul Latif";
            IsSelected = false;


        }
        #endregion
    }
}