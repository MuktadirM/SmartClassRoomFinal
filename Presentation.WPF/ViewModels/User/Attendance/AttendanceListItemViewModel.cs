
using Presentation.WPF.Commands.Callbcks;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Presentation.UsersV.ViewModels
{
    public enum AType{
        Absent,
        Present,
        Excause,
        NotTaken
    }
    /// <summary>
    /// Class AttendanceListItemViewModel
    /// Write your documentation here
    /// </summary>
    public class AttendanceListItemViewModel:INotifyPropertyChanged
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public long Matric { get; set; }
        public string CourseName { get; set; }
        public AType Type { get; set; }
        public DateTime LastTakenAt { get; set; }
        public DateTime TakenAt { get; set; }
        public string Initials { get; set; }
        public bool IsSelected { get; set; }
        public string LecturerName { get; set; }
        public string ProfilePictureRGB { get; set; }
        public string EmotionType { get; set; } = "Not Detected";



        #region constructor
        public AttendanceListItemViewModel() {
            
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _isAbsent = false;
        public bool IsAbsent { get =>
                _isAbsent= AType.Absent == Type;
            set {
                _isAbsent = value;
                Type = AType.Absent;
                OnPropertyChanged(nameof(IsAbsent));
            } }
        private bool _isPresent = false;
        public bool IsPresent { get=> 
                _isPresent = AType.Present == Type; 
            set {
                _isPresent = value;
                Type = AType.Present;
                OnPropertyChanged(nameof(IsPresent));
            } }
        private bool _isExcause = false;
        public bool IsExcuase {
            get =>
                _isExcause = AType.Excause == Type; 
            set
            {
                _isExcause = value;
                Type = AType.Excause;
                OnPropertyChanged(nameof(IsExcuase));
            }
        }
        private bool _notTaken = false;
        public bool NotTaken {
            get => _notTaken = AType.NotTaken == Type; 
            set
            {
                _notTaken = value;
                Type = AType.NotTaken;
                OnPropertyChanged(nameof(NotTaken));
            }
        }

        public string ATypeText => TypeToText(this.Type);

        public string TypeToText(AType type)
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




    }
}