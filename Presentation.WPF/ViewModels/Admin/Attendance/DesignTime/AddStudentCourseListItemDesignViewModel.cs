
namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class CourseListItemDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class AddStudentCourseListItemDesignViewModel : AddStudentCourseListItemViewModel
    {
        public static AddStudentCourseListItemDesignViewModel Instance => new AddStudentCourseListItemDesignViewModel();

        #region constructor
        public AddStudentCourseListItemDesignViewModel() {
            SectionId = 23;
            CourseCode = "IAS2233";
            Name = "INformation System";
            LecturerName = "Monibur Rahman";
            IsSelected = false;
        }
        #endregion
    }
}