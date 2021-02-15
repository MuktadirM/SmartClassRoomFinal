
using SmartClassRoom.Domain.Models.Core;
using System;

namespace Presentation.WPF.ViewModels
{
    /// <summary>
    /// Class RoomStatusListItem 
    /// Write your documentation here
    /// </summary>
    public class RoomStatusListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomBookedBy { get; set; }
        public RoomStatusType RoomStatusType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public string Status => GetStatus(this.RoomStatusType);
        #region constructor
        #endregion

        public string GetStatus(RoomStatusType room) {
            string status = "";
            switch (room)
            {
                case RoomStatusType.Booked:
                    status = "Engage";
                    break;
                case RoomStatusType.Free:
                    status = "Vacant";
                    break;
                case RoomStatusType.Maintenance:
                    status = "Maintenance";
                    break;
            }

            return status;
        }
    }
}
