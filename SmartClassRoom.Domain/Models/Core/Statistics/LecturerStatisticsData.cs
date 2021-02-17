
using System.Collections.Generic;

namespace SmartClassRoom.Domain.Models.Core.Statistics
{
    /// <summary>
    /// Class LecturerStatisticsData
    /// Write your documentation here
    /// </summary>
    public class LecturerStatisticsData
    {
        public int Courses { get; set; }
        public int Attendances { get; set; }
        public int Students { get; set; }
        public int AttendancePercent { get; set; }
        public Dictionary<string, int> CourseStudents { get; set; }
        public Dictionary<string, int> CourseAttendances { get; set; }
        public Dictionary<string, int> CourseAttendancePercent { get; set; }
    }
}