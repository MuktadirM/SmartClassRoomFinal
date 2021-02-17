
namespace SmartClassRoom.Domain.Models.AttendanceProcessing
{
    public enum EmotionType
    {
        Anger,
        Sad,
        Happy,
        Smile,
        Fear,
        Disgust,
        Contempt,
        Neutral,
        Surprise,
        Unknown,
        Undetected,
        
    }

    /// <summary>
    /// Class StudentFaceAttendance
    /// Write your documentation here
    /// </summary>
    public class StudentFaceAttendance
    {
        public long Matric { get; set; }
        public AttendanceType AttendanceType { get; set; } = AttendanceType.Undetected;
        public EmotionType EmotionType { get; set; } = EmotionType.Undetected;
        public int ConfidanceLevel { get; set; } = 0;

        #region constructor
        #endregion
    }
}