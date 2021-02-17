
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Core.Statistics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartClassRoom.Domain.Services
{
    /// <summary>
    /// Interface IStatisticsDataServices 
    /// Write your documentation here 
    /// </summary>
    public interface IStatisticsDataServices
    {
        public Task<StatisticsData> GetAll();
        public Task<LecturerStatisticsData> LecturerStatisticsData(int id);
        public Task<IEnumerable<Course>> LecturerCourses(int id);
    }
}
