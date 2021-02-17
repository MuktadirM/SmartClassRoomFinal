using Presentation.ViewModels;
using Presentation.WPF.ViewModels;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System.Collections.ObjectModel;


namespace Presentation.UsersV.ViewModels
{
    public class RoomStatusViewModel : BaseViewModel
    {
        private readonly IRoomServices _roomServices;

        public ObservableCollection<RoomStatusListItem> ListOfRoomInfo { get; set; } = new ObservableCollection<RoomStatusListItem>();

        public RoomStatusViewModel(IRoomServices roomServices) {
            _roomServices = roomServices;

            LoadRoom();
        }

        private async void LoadRoom() {
            ListOfRoomInfo.Clear();

            var statuses = await _roomServices.GetAll();
            foreach (var status in statuses) {
                ListOfRoomInfo.Add(new RoomStatusListItem { 
                    Name = status.Name,
                    RoomBookedBy = status.RoomBookedBy,
                    RoomStatusType = status.RoomStatusType,
                    StartTime = status.StartTime,
                    EndTime = status.EndTime,
                });
            }

        }

        public string RoomE(RoomStatusType roomStatus) {
            return roomStatus switch
            {
                RoomStatusType.Booked => "Engage",
                RoomStatusType.Free => "Vacant",
                RoomStatusType.Maintenance => "Maintenance",
                _ => "Unknown",
            };
        }
    }
}
