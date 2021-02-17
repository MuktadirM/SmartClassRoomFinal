
using System;

namespace SmartClassRoom.Domain.Models.Core
{
    /// <summary>
    /// Class StatisticsData
    /// Write your documentation here
    /// </summary>
    public class StatisticsData
    {
        public int Users { get; set; } = 0;
        public int Courses { get; set; } = 0;
        public int Lecturers { get; set; } = 0;
        public int Students { get; set; } = 0;
        public int StudentFaceAdded { get; set; } = 0;
        public int Registrations { get; set; } = 0;
        public int Sections { get; set; } = 0;
        public int Attendances { get; set; } = 0;
        public int AttendancePercent { get; set; } = 0;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}