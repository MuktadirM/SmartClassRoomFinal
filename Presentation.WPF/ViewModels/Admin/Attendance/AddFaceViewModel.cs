
using Microsoft.Win32;
using Presentation.WPF.Commands.Callbcks;
using Presentation.WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Presentation.ViewModels;
using SmartClassRoom.Domain.Services;
using System.Globalization;
using System.Text;
using SmartClassRoom.Domain.Services.FaceServices;
using SmartClassRoom.Domain.Models.FaceProcessing;
using System.Collections.Generic;
using SmartClassRoom.Domain.Services.StudentServices;

namespace Presentation.Admin.ViewModels
{
    /// <summary>
    /// Class AddFaceViewModel
    /// Write your documentation here
    /// </summary>
    public class AddFaceViewModel : BaseViewModel
    {
        private StudentListItemViewModel _studentListViewItem { get; set; }
        public ObservableCollection<FileOperation> FilesPath { get; set; } = new ObservableCollection<FileOperation>();

        private string _traning { get; set; }

        public string TraningStatus { get => _traning;
            set {
                _traning = value;
                OnPropertyChanged(TraningStatus);
            }
        }



        public StudentListItemViewModel SelectedStudent{
            get => _studentListViewItem;
            set { _studentListViewItem = value;
                OnPropertyChanged(nameof(SelectedStudent));
                OnPropertyChanged(nameof(SelectImageFor));
            }
        }

        private ObservableCollection<StudentListItemViewModel> _listOfStudents { get; set; } =
        new ObservableCollection<StudentListItemViewModel>();

        public ObservableCollection<StudentListItemViewModel> ListOfStudents {
            get => _listOfStudents;
            set {
                _listOfStudents = value;
                OnPropertyChanged(nameof(ListOfStudents));
            } }
            

        public ICommand ItemSelected { get; set; }
        public ICommand StartTraning { get; set; }

        private readonly IStudentService _studentService;
        private readonly IStudentFaceService _studentFaceService;

        #region constructor
        public AddFaceViewModel(IStudentService studentService, IStudentFaceService studentFaceService)
        {
            _studentService = studentService;
            _studentFaceService = studentFaceService;

            ItemSelected = new RelayCommand(OpenFileDialog);
            StartTraning = new RelayACommand(Traning);
            InitStudent();
        }
        #endregion
        private async void InitStudent() {
            NoFaceFound.Clear();

            var stu = await GetStudentsAsync();
            foreach (var s in stu) {
                _listOfStudents.Add(s);
                if (!s.FaceAdded) {
                    NoFaceFound.Add(s);
                }
            }

            
        }

        public ObservableCollection<StudentListItemViewModel> NoFaceFound { get; set; } = new ObservableCollection<StudentListItemViewModel>();

        public string SelectImageFor => SelectedStudent==null? "No Student Selected": "Select image for " + SelectedStudent.Name;

        private void OpenFileDialog(object obj) {
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
                    FileOperation file = new FileOperation {
                        FileName = "Image"+ i++,
                        FilePath = path,
                    };

                    FilesPath.Add(file);

                }
            }
            if (FilesPath.Count > 4) {
                int extra = FilesPath.Count - 4;
                for(int ex = 0; ex != extra;) {
                    FilesPath.RemoveAt(4);
                    ex++;
                }
                MessageBox.Show("File Selected more than 4\n Your file after 4 will be removed ", "Your file can't be more than 4");
            }

        }

        private async void Traning() {
            if (FilesPath.Count < 1 || SelectedStudent == null) {
                MessageBox.Show("Sorry Image and student should be select","Error");
                return;
            }

            //try
            //{
            //    await _faceservice.CreateAttendanceGroup();
            //}
            //catch
            //{
            //    MessageBox.Show("Group Already created", "");
            //}

            var listImage = new List<string>();

            foreach (var file in FilesPath) {
                listImage.Add(file.FilePath);    
            }

            FaceProcess studentImage = new FaceProcess {
                Id = SelectedStudent.Id,
                Matric = SelectedStudent.Matric,
                Name = SelectedStudent.Name,
                Images = listImage
            };
            TraningStatus = "Running..";
            OnPropertyChanged(nameof(TraningStatus));

            //await _faceservice.DeleteAttendanceGroup();

            var result = await _studentFaceService.AddFace(studentImage);

            if (result)
            {
                var traningStatus = await _studentFaceService.TraningStatus();


                if (traningStatus.Status == Microsoft.Azure.CognitiveServices.Vision.Face.Models.TrainingStatusType.Succeeded)
                {
                    TraningStatus = "Completed";
                    OnPropertyChanged(nameof(TraningStatus));
                }

                MessageBox.Show("Student face added", "Success");
                FilesPath.Clear();
                InitStudent();
            }

        }


        private async Task<ObservableCollection<StudentListItemViewModel>> GetStudentsAsync() {
            ObservableCollection<StudentListItemViewModel> students = new ObservableCollection<StudentListItemViewModel>();

            var studentsAll = await _studentService.GetAll();

            foreach (var student in studentsAll)
            {
                students.Add(new StudentListItemViewModel
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
            return students;
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