using Presentation.ViewModels;
using Presentation.WPF.State.Authenticators;
using SmartClassRoom.Domain.Models.Users;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Presentation.UsersV.ViewModels
{
    public class ViewAttendanceViewModel : BaseViewModel
    {
        public ObservableCollection<AttendanceListItemViewModel> Items { get; set; } = new ObservableCollection<AttendanceListItemViewModel>();

        private readonly ILecturerService _lecturerService;
        private readonly IAuthenticator _authenticator;
        private readonly IAttendanceService _attendanceService;

        public ViewAttendanceViewModel(ILecturerService lecturerService, 
            IAuthenticator authenticator, 
            IAttendanceService attendanceService)
        {
            _lecturerService = lecturerService;
            _authenticator = authenticator;
            _attendanceService = attendanceService;

            LoadAttendance();
        }

        private async void LoadAttendance() {
            Lecturer lectuer = await _lecturerService.GetOne(_authenticator.CurrentAccount.User.Id);

            var attendances = await _attendanceService.GetAll();

            foreach(var atten in attendances)
            {
                Items.Add(new AttendanceListItemViewModel
                {
                    StudentId = atten.Registration.Student.Id,
                    Name = atten.Registration.Student.Name,
                    Matric = atten.Registration.Student.Matric,
                    CourseName = atten.Registration.Section.Course.CourseName,
                    LastTakenAt = (DateTime)atten.Registration.CreatedAt,
                    TakenAt = (DateTime)atten.CreatedAt,
                    ProfilePictureRGB = RandomRGBColor(),
                    LecturerName = "Ali Akbor",
                    Type = GetType(atten.AttendanceType),
                    Initials = GetInitials(atten.Registration.Student.Name),
            });
            }

        }

        public static string AttendanceTypeToText(AType type) {
            return type switch
            {
                AType.Absent => "Absent",
                AType.Present => "Present",
                AType.Excause => "Excause",
                AType.NotTaken => "Not Taken",
                _ => "Not Taken",
            };
        }

        private AType GetType(int type)
        {
            return type switch
            {
                0 => AType.Absent,
                1 => AType.Present,
                2 => AType.Excause,
                3 => AType.NotTaken,
                _ => AType.NotTaken,
            };
        }

        private string RandomRGBColor()
        {
            Random random = new Random();
            var color = String.Format("{0:X6}", random.Next(0x1000000)); // = "#A197B9"
            return color;
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
    }
}
