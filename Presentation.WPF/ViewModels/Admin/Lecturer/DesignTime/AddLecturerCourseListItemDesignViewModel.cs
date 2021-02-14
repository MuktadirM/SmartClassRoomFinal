
namespace Presentation.Admin.ViewModels.DesignTime
{
    /// <summary>
    /// Class CourseListItemDesignViewModel
    /// Write your documentation here
    /// </summary>
    public class AddLecturerCourseListItemDesignViewModel : AddLecturerCourseListItemViewModel
    {
        public static AddLecturerCourseListItemDesignViewModel Instance => new AddLecturerCourseListItemDesignViewModel();

        #region constructor
        public AddLecturerCourseListItemDesignViewModel() {
            CourseId = 23;
            CourseCode = "IAS2233";
            Name = "Information System";
            IsSelected = false;
        }
        #endregion
    }
}