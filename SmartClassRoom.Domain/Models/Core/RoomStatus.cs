
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
        public string Name { get; set; }
        public string RoomBookedBy { get; set; }
        public RoomStatusType RoomStatusType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}