using Presentation.ViewModels;
using Presentation.WPF.State.Authenticators;
using SmartClassRoom.Domain.Models.Core.Statistics;
using SmartClassRoom.Domain.Services;

namespace Presentation.UsersV.ViewModels
{
    public class UserDashboardViewModel : BaseViewModel
    {
        private readonly IStatisticsDataServices _statisticsDataServices;
        private readonly IAuthenticator _authenticator;

        public LecturerStatisticsData LecturerStatisticsData { get; set; }

        public UserDashboardViewModel(IStatisticsDataServices statisticsDataServices, IAuthenticator authenticator)
        {
            _statisticsDataServices = statisticsDataServices;
            _authenticator = authenticator;
            LoadHomeData();
        }

        private async void LoadHomeData()
        {
            //var data = await _statisticsDataServices.LecturerStatisticsData(_authenticator.CurrentAccount.User.Id);
            //LecturerStatisticsData = data;
            //OnPropertyChanged(nameof(LecturerStatisticsData));

        }


    }
}
