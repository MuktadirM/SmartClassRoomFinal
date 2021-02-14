using Presentation.ViewModels;
using Presentation.WPF.ViewModels;
using SmartClassRoom.Domain.Models.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.UsersV.ViewModels
{
    public class RoomStatusViewModel : BaseViewModel
    {
        public ObservableCollection<RoomStatusListItem> ListOfRoomInfo { get; set; }

        public RoomStatusViewModel() {

            ListOfRoomInfo = new ObservableCollection<RoomStatusListItem>(){
                new RoomStatusListItem {
                    Id=1,
                    Name = "BK1",
                    RoomBookedBy = "Dr. Haslinda",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Today,
                    RoomStatusType = RoomStatusType.Booked,
                },
                new RoomStatusListItem {
                    Id=2,
                    Name = "BK2",
                    RoomBookedBy = "None",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Today,
                    RoomStatusType = RoomStatusType.Free,
                },
                new RoomStatusListItem {
                    Id=3,
                    Name = "BK4",
                    RoomBookedBy = "Dr. Hema",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Today,
                    RoomStatusType = RoomStatusType.Booked,
                },
                new RoomStatusListItem {
                    Id=4,
                    Name = "BK9",
                    RoomBookedBy = "None",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Today,
                    RoomStatusType = RoomStatusType.Free,
                },
                new RoomStatusListItem {
                    Id=5,
                    Name = "BK7",
                    RoomBookedBy = "None",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Today,
                    RoomStatusType = RoomStatusType.Maintenance,
                },
            };
        }
    }
}
