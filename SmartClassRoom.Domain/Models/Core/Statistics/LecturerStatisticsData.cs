
using System;
using System.Collections.Generic;

namespace SmartClassRoom.Domain.Models.Core.Statistics
{
    /// <summary>
    /// Class LecturerStatisticsData
    /// Write your documentation here
    /// </summary>
    public class LecturerStatisticsData
    {
        public int Courses { get; set; } = 0;
        public int Attendances { get; set; } = 0;
        public int Students { get; set; } = 0;
        public int AttendancePercent { get; set; } = 0;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public Dictionary<string, int> CourseStudents { get; set; }
        public Dictionary<string, int> CourseAttendances { get; set; }
        public Dictionary<string, int> CourseAttendancePercent { get; set; }
    }
}