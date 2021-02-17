using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using System.Threading.Tasks;

namespace ClassRoomDataAPI
{
    /// <summary>
    /// Class RoomServices
    /// Write your documentation here
    /// </summary>
    public class RoomServices : IRoomServices
    {
        #region constructor
        #endregion

        public Task<RoomStatus> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}