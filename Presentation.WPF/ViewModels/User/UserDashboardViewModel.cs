using Presentation.ViewModels;
using Presentation.WPF.State.Authenticators;
using SmartClassRoom.Domain.Models.Core;
using SmartClassRoom.Domain.Models.Core.Statistics;
using SmartClassRoom.Domain.Services;
using System.Collections.ObjectModel;

namespace Presentation.UsersV.ViewModels
{
    public class UserDashboardViewModel : BaseViewModel
    {
        private readonly IStatisticsDataServices _statisticsDataServices;
        private readonly IAuthenticator _authenticator;

        public LecturerStatisticsData LecturerStatisticsData { get; set; }

        public ObservableCollection<Course> Items { get; set; } = new ObservableCollection<Course>();

        public UserDashboardViewModel(IStatisticsDataServices statisticsDataServices, IAuthenticator authenticator)
        {
            _statisticsDataServices = statisticsDataServices;
            _authenticator = authenticator;
            LoadHomeData();
        }

        private async void LoadHomeData()
        {
            var data = await _statisticsDataServices.LecturerStatisticsData(_authenticator.CurrentAccount.User.Id);
            LecturerStatisticsData = data;
            OnPropertyChanged(nameof(LecturerStatisticsData));

           var courses = await _statisticsDataServices.LecturerCourses(_authenticator.CurrentAccount.User.Id);
            Items.Clear();
            foreach (var course in courses) {
                Items.Add(course);
            }
        }




    }
}
