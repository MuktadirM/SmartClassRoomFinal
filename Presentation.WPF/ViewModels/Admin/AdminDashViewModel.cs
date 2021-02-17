using Presentation.ViewModels;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.CourseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Admin.ViewModels
{
   public class AdminDashViewModel : BaseViewModel
    {

        private readonly IStatisticsDataServices _statisticsDataServices;

        public StatisticsData StatisticsData { get; set; }
        public string AttendancePercent { get; set; }
        public string TeachingInfo { get; set; }

        public AdminDashViewModel(IStatisticsDataServices statisticsDataServices)
        {
            _statisticsDataServices = statisticsDataServices;
            LoadStatisticsData();
        }

        private async void LoadStatisticsData() {
            StatisticsData = await _statisticsDataServices.GetAll();
            AttendancePercent = StatisticsData.AttendancePercent+"%";
            TeachingInfo = StatisticsData.Sections + " Classes";
            OnPropertyChanged(nameof(TeachingInfo));
            OnPropertyChanged(nameof(AttendancePercent));
            OnPropertyChanged(nameof(StatisticsData));
        }


    }
}
