using Microsoft.Win32;
using Presentation.Admin.ViewModels;
using Presentation.ViewModels;
using Presentation.WPF.Commands.Callbcks;
using Presentation.WPF.Models;
using Presentation.WPF.State.Authenticators;
using Presentation.WPF.Views.Common;
using SmartClassRoom.Domain.Models.AttendanceProcessing;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Users;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using SmartClassRoom.Domain.Services.StudentServices;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Presentation.UsersV.ViewModels
{
    public class TakeAttendanceViewModel : BaseViewModel
    {
       
        private readonly ICourseServices _courseServices;
        private readonly IStudentFaceService _studentFaceService;
        private readonly ILecturerService _lecturerService;
        private readonly IAuthenticator _authenticator;
        private readonly IAttendanceService _attendanceService;

        private AType aType { get; set; }

        public ObservableCollection<FileOperation> FilesPath { get; set; } = new ObservableCollection<FileOperation>();
        /// <summary>
        /// All avaiable courses
        /// </summary>
        public ObservableCollection<AddStudentCourseListItemViewModel> CourseListItems { get; set; } =
            new ObservableCollection<AddStudentCourseListItemViewModel>();

        /// <summary>
        /// Selected course from list
        /// </summary>
        public StudentOfferedCourseListItemViewModel SelectdOfferedCourseListItemViewModel { get; set; }

        public ObservableCollection<AttendanceListItemViewModel> Items { get; set; } = new ObservableCollection<AttendanceListItemViewModel>();

        /// <summary>
        /// The selected course from combo box item ready to Load Student
        /// </summary>
        private AddStudentCourseListItemViewModel _selectedCourse;

        public AddStudentCourseListItemViewModel SelectedCourseItem
        {
            get => _selectedCourse; 

            set {
                _selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourseItem));
                OnPropertyChanged(nameof(SelectImageFor));
            }
        }

        public AttendanceListItemViewModel SelectedStudent { get; set; }

        public ICommand ItemSelected { get; set; }
        public ICommand ProcessAttendance { get; set; }
        public ICommand SubmitAttendance { get; set; }
        public ICommand LoadStudent { get; set; }
        public ICommand AttendanceChanged { get; set; }
        public ICommand ChangeAttendance { get; set; }
        public ICommand OpenCamera { get; set; }


        public TakeAttendanceViewModel(ICourseServices courseServices, IStudentFaceService studentFaceService,
            IAttendanceService attendanceService,
            IAuthenticator authenticator,
            ILecturerService lecturerService
            )
        {
            _courseServices = courseServices;
            _studentFaceService = studentFaceService;
            _attendanceService = attendanceService;
            _authenticator = authenticator;
            _lecturerService = lecturerService;

            ItemSelected = new RelayCommand(OpenFileDialog);
            ProcessAttendance = new RelayACommand(ProcessAttendStudent);
            SubmitAttendance = new RelayACommand(SubmitAttenStudent);
            LoadStudent = new RelayACommand(LoadAllStudent);
            ChangeAttendance = new RelayACommand(ChangeAttendanceType);
            AttendanceChanged = new RelayCommand(AttendanceModified);
            OpenCamera = new RelayACommand(OpenCemraAction);
            GetCourses();
            
        }

        public string SelectImageFor => SelectedCourseItem == null ? "No Course Selected" : "Select student image for " + SelectedCourseItem.Name;

        /// <summary>
        /// Look for student attendance using image
        /// </summary>
        private async void ProcessAttendStudent() {
            if (FilesPath.Count() > 0 && SelectedCourseItem != null)
            {
                Section section = new Section {Id = SelectedCourseItem.SectionId};
                var attends = await _studentFaceService.GetStudentFaceAttendances(FilesPath[0].FilePath,section);
                if (attends.Count() != 0)
                {
                    foreach (var at in attends)
                    {
                        var item = Items.FirstOrDefault(s => s.Matric == at.Matric);
                        if (item != null && at.ConfidanceLevel > 80)
                        {
                            item.Type = AType.Present;
                            item.EmotionType = GetEmotion(at.EmotionType);
                            RefreshList(item);
                        }
                        else
                        {
                            if (item != null)
                            {
                                item.Type = AType.Absent;
                                RefreshList(item);
                            }
                        }
                    }
                    MessageBox.Show("Attendance completed ", "Success");
                }
                else {
                    MessageBox.Show("Attendance completed 0 Student found", "Success");
                }
               
            }
            else {
                MessageBox.Show("No Student Image selected ", "Error");
            }
          
        }

        private void OpenCemraAction() {
            CameraAccess camera = new CameraAccess();
            camera.Show();
        }

        private void ChangeAttendanceType() {
            if (SelectedStudent != null)
            {
                MessageBox.Show(aType + " Attendance", "Check");
                var item = Items.FirstOrDefault(s => s.StudentId == SelectedStudent.StudentId);
                if (item != null)
                {
                    item.Type = aType;
                    RefreshList(item);
                }
            }
            else {
                MessageBox.Show("Must have to Select a student", "Check");
            }
        }

        private void RefreshList(AttendanceListItemViewModel item) {
            int co = Items.IndexOf(item);
            Items.RemoveAt(co);
            Items.Add(item);
        }

        private void AttendanceModified(object obj)
        {
            var atten = (string)obj;
            aType = GetType(atten);
        }

        private async void SubmitAttenStudent() {
            Lecturer lectuer = await _lecturerService.GetOne(_authenticator.CurrentAccount.User.Id);

            foreach (var item in Items) {
                Student student = new Student { 
                    Id = item.StudentId,
                    Matric = item.Matric,
                    Name = item.Name,
                };

                Attendance attendance = new Attendance {
                    AttendProcessId = SelectedCourseItem.ProcessId,
                    AttendanceType = (int)item.Type,
                    StudentId = item.StudentId,
                    CourseId = SelectedCourseItem.Id,
                    LecturerId = lectuer.Id,
                    RegistrationId = item.RegistrationId,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = lectuer.Id,
                };

                await _attendanceService.TakeAttendance(student,attendance);
            }
            MessageBox.Show("Attendance Successfully Compeleted","Success",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private AType GetType(string type)
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

        private void LoadAllStudent() {
            Section section = new Section { Id = SelectedCourseItem.SectionId };
            Items.Clear();
            GetStudents(section);
        }

        private async void GetStudents(Section Section)
        {
            var registeredStudents = await _courseServices.GetCourseStudentsBySection(Section);
            foreach (var student in registeredStudents) {
                    Items.Add(new AttendanceListItemViewModel { 
                            RegistrationId = student.Id,
                            StudentId = student.StudentId,
                            Name = student.Student.Name,
                            SectionId = student.SectionId,
                            CourseName = SelectedCourseItem.Name,
                            LastTakenAt = student.Section.AttendProcess.LastUpdated,
                            Type = AType.NotTaken,
                            Initials = GetInitials(student.Student.Name),
                            ProfilePictureRGB = RandomRGBColor(),
                            Matric = student.Student.Matric,
                    });
            }
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

        private void OpenFileDialog(object obj)
        {
            FilesPath.Clear();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Images(*.BMP; *.JPG; *.PNG)|*.BMP; *.JPG; *.PNG";
            open.Multiselect = true;

            open.Title = SelectImageFor;
            if (open.ShowDialog() == true)
            {
                int i = 1;
                foreach (String path in open.FileNames)
                {
                    FileOperation file = new FileOperation
                    {
                        FileName = "Image" + i++,
                        FilePath = path,
                    };

                    FilesPath.Add(file);

                }
            }
            if (FilesPath.Count > 1)
            {
                int extra = FilesPath.Count - 1;
                for (int ex = 0; ex != extra;)
                {
                    FilesPath.RemoveAt(1);
                    ex++;
                }
                MessageBox.Show("File Selected more than 1\n Your file after 1 will be removed ", "Your file can't be more than 1");
            }

        }

        private async void GetCourses()
        {
            Lecturer lectuer = await _lecturerService.GetOne(_authenticator.CurrentAccount.User.Id);

            var allSections = await _courseServices.GetAllSections();

            foreach (var section in allSections.Where(s=>s.LecturerId == lectuer.Id).ToList())
            {
                CourseListItems.Add(
               new AddStudentCourseListItemViewModel
               {
                   Id = section.CourseId,
                   SectionId = section.Id,
                   CourseCode = section.Course.CourseCode,
                   Name = section.Course.CourseName,
                   LecturerName = section.Lecturer.User.Name,
                   JoinDate = section.CreatedAt ?? DateTime.MinValue,
                   IsSelected = false,
                   ProcessId = section.AttendProcess.AttendProcessId,
               });
            }
        }

        private string GetEmotion(EmotionType emotionType) {
            return emotionType switch
            {
                EmotionType.Anger => "Anger",
                EmotionType.Sad => "Sad",
                EmotionType.Happy => "Happy",
                EmotionType.Smile => "Smile",
                EmotionType.Fear => "Fear",
                EmotionType.Disgust => "Disgust",
                EmotionType.Contempt => "Contempt",
                EmotionType.Neutral => "Neutral",
                EmotionType.Surprise => "Surprise",
                EmotionType.Unknown => "Unknown",
                EmotionType.Undetected => "Undetected",
                _ => "Not found",
            };
        }
    }
}
