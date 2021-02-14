
using System;
using System.ComponentModel.DataAnnotations;

namespace SmartClassRoom.Domain.Models.Core
{
    public enum RoomStatusType
    {
        Booked,
        Free,
        Maintenance
    }
    /// <summary>
    /// Class RoomStatus
    /// Write your documentation here
    /// </summary>
    public class RoomStatus : DomainObject
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10)]
        public int? RoomBookedBy { get; set; }
        public RoomStatusType RoomStatusType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}