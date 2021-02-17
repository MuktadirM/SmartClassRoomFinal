
using System;

namespace SmartClassRoom.Domain.Models.Core
{
    /// <summary>
    /// Class StatisticsData
    /// Write your documentation here
    /// </summary>
    public class StatisticsData
    {
        public int Users { get; set; }
        public int Courses { get; set; }
        public int Lecturers { get; set; }
        public int Students { get; set; }
        public int StudentFaceAdded { get; set; }
        public int Registrations { get; set; }
        public int Sections { get; set; }
        public int Attendances { get; set; }
        public int AttendancePercent { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}