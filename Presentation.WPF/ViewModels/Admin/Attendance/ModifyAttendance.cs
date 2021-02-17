
using Presentation.UsersV.ViewModels;
using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class ModifyAttendance
    /// Write your documentation here
    /// </summary>
    public class ModifyAttendanceViewModel : BaseViewModel
    {
        private readonly IAttendanceService _attendanceService;

        private AttendanceListItemViewModel _attendSelected { get; set; }
        public AttendanceListItemViewModel SelectedAttendance 
        { get=>_attendSelected;
            set {
                _attendSelected = value;
                OnPropertyChanged(nameof(SelectedAttendance));
                OnPropertyChanged(nameof(AttendanceSelectedInfo));

            } 
        }

        public string AttendanceSelectedInfo => SelectedAttendance == null ? "No Student Selected" : "Student Name : "+SelectedAttendance.Name+ "\n" 
            +"Course Name : " + SelectedAttendance.CourseName +"\n" + "Taken At : "+SelectedAttendance.TakenAt +"\n"+ "Attendance type : "+
            SelectedAttendance.ATypeText;

        public ICommand ItemSelected { get; set; }
        public ICommand AttendanceChanged { get; set; }
        public AType NewAttendance { get; set; }
        public bool NoAttendance { get; set; } = true;
        public ObservableCollection<AttendanceListItemViewModel> Items { get; set; } = new ObservableCollection<AttendanceListItemViewModel>();
        

        public ModifyAttendanceViewModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
            ItemSelected = new RelayACommand(SelectedItem);
            AttendanceChanged = new RelayCommand(AttendanceModified);

            LoadAttendance();
        }

        public void SelectedItem() {
            if (SelectedAttendance == null) {
                MessageBox.Show("Please Select A Student","Selection Error",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            if (NoAttendance) {
                MessageBox.Show("Please Select Attendance for Student", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var item = new Attendance {
                Id = SelectedAttendance.Id,
                AttendanceType = (int)NewAttendance,
                LastUpdated = DateTime.Now,
            };


            _attendanceService.UpdateAttendanceOnly(item).ContinueWith((task)=> {
                if (task.Exception == null) {
                    MessageBox.Show("Attendance updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });
        }
        private void AttendanceModified(object obj)
        {
            var atten = (string)obj;
            NewAttendance = GetTypeS(atten);
            OnPropertyChanged(nameof(NewAttendance));
            NoAttendance = false;
        }

        private async void LoadAttendance()
        {
            var attendances = await _attendanceService.GetAll();

            foreach (var atten in attendances)
            {
                Items.Add(new AttendanceListItemViewModel
                {
                    Id = atten.Id,
                    StudentId = atten.Registration.Student.Id,
                    Name = atten.Registration.Student.Name,
                    Matric = atten.Registration.Student.Matric,
                    CourseName = atten.Registration.Section.Course.CourseName,
                    LastTakenAt = (DateTime)atten.Registration.CreatedAt,
                    TakenAt = (DateTime)atten.CreatedAt,
                    ProfilePictureRGB = RandomRGBColor(),
                    LecturerName = "",
                    Type = GetType(atten.AttendanceType),
                    Initials = GetInitials(atten.Registration.Student.Name),
                }); 
            }

        }

        public static string AttendanceTypeToText(AType type)
        {
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

        private AType GetTypeS(string type)
        {
            return type switch
            {
                "Absent" => AType.Absent,
                "Present" => AType.Present,
                "Excause" => AType.Excause,
                "Not Taken" => AType.NotTaken,
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