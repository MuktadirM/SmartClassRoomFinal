
using SmartClassRoom.Domain.Models.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    /// <summary>
    /// Interface IRoomServices 
    /// Write your documentation here 
    /// </summary>
    public interface IRoomServices
    {
        /// <summary>
        /// Write your documentation here
        /// </summary>
        public Task<IEnumerable<RoomStatus>> GetAll();
    }
}
