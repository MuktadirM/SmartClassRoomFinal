
using Presentation.ViewModels;
using SmartClassRoom.Domain.Services.CourseServices;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class CoursesViewModel
    /// Write your documentation here
    /// </summary>
    public class CoursesViewModel : BaseViewModel
    {
        private readonly ICourseServices _services;
        public ObservableCollection<CourseListItemViewModel> Items { get; set; } = new ObservableCollection<CourseListItemViewModel>();

        #region constructor
        public CoursesViewModel(ICourseServices services) {
            _services = services;

            GetAllCourses();
        }
        #endregion

        public async void  GetAllCourses() {
            var courses = await _services.GetAll();
            foreach (var course in courses)
            {
                Items.Add(
                         new CourseListItemViewModel
                        {
                            Id = course.Id,
                            Initials = GetInitials(course.CourseName),
                            Name = course.CourseName,
                            CourseCode = course.CourseCode,
                            Faculty = course.Faculty,
                            CoursePictureRGB = RandomRGBColor(),
                            JoinDate = course.CreatedAt ?? DateTime.MinValue,
                            StudentCount = course.Sections.Count(),
                            IsSelected = false,
                        }
                    );
            }

        }


        public static string GetInitials(string courseName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var two = courseName.Split(" ");
            if (two.Length == 2)
            {
                stringBuilder.Append(TruncateLongString(two[0], 1));
                stringBuilder.Append(TruncateLongString(two[1], 1));
            }
            else {
                stringBuilder.Append(TruncateLongString(two[0], 2));
            }
            return stringBuilder.ToString().ToUpper();
        }

        public static string TruncateLongString(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string FormatDateTime(DateTime? dateTime) {
            try
            {
                DateTime? dt = DateTime.ParseExact(dateTime.ToString(), "ddMMyyyy",
                              CultureInfo.InvariantCulture);
                return dt?.ToString("yyyyMMdd-HHmmss");
            }
            catch
            {
                return "Not Found";
            }
        }

        public static string RandomRGBColor() {
            Random random = new Random();
            var color = String.Format("{0:X6}", random.Next(0x1000000)); // = "#A197B9"
            return color;
        }
    }
}