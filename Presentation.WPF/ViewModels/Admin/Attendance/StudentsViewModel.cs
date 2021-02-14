using Presentation.ViewModels;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class StudentsViewModel
    /// Write your documentation here
    /// </summary>
    public class StudentsViewModel : BaseViewModel
    {
        private readonly IStudentService _studentService;

        public ObservableCollection<StudentListItemViewModel> Items { get; set; } = new ObservableCollection<StudentListItemViewModel>();

        #region constructor

        public StudentsViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            LoadAllStudents();
        }

        #endregion

        private async void LoadAllStudents() {
            var students = await _studentService.GetAll();

            foreach (var student in students) {
                Items.Add(new StudentListItemViewModel
                {
                    Id = student.Id,
                    Initials = GetInitials(student.Name),
                    Faculty = student.Faculty,
                    Name = student.Name,
                    Matric = student.Matric.ToString(),
                    FaceAdded = student.FaceAdded,
                    JoinDate = student.CreatedAt,
                    ProfilePictureRGB = RandomRGBColor(),
                }); 
            }
        }

        public static string GetInitials(string anyString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var two = anyString.Split(" ");
            if (two.Length == 2)
            {
                stringBuilder.Append(TruncateLongString(two[0], 1));
                stringBuilder.Append(TruncateLongString(two[1], 1));
            }
            else
            {
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

        public static string FormatDateTime(DateTime? dateTime)
        {
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

        public static string RandomRGBColor()
        {
            Random random = new Random();
            var color = String.Format("{0:X6}", random.Next(0x1000000)); // = "#A197B9"
            return color;
        }
    }
}