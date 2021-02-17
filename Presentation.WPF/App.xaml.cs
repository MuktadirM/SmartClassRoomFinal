using ClassRoomDataAPI;
using DataAccessLayer;
using DataAccessLayer.Services;
using FaceProcessing.Face;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Admin.ViewModels;
using Presentation.UsersV.ViewModels;
using Presentation.ViewModels;
using Presentation.WPF.State.Accounts;
using Presentation.WPF.State.Authenticators;
using Presentation.WPF.State.Navigators;
using Presentation.WPF.ViewModels.Common;
using Presentation.WPF.ViewModels.Factories;
using SmartClassRoom.Domain.Services;
using SmartClassRoom.Domain.Services.AuthenticationServices;
using SmartClassRoom.Domain.Services.CourseServices;
using SmartClassRoom.Domain.Services.FaceServices;
using SmartClassRoom.Domain.Services.StudentServices;
using System;
using System.Windows;

namespace Presentation.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App() {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                    c.AddEnvironmentVariables();
                }).ConfigureServices((context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString("MSSQL");
                    string faceEndPoint = context.Configuration["FaceKeys:FACE_ENDPOINT"];
                    string faceKey = context.Configuration["FaceKeys:FACE_SUBSCRIPTION_KEY"];

                    Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);
                    services.AddDbContext<DatabaseContext>(configureDbContext);
                    services.AddSingleton<DatabaseContextFactory>(new DatabaseContextFactory(configureDbContext));

                    services.AddSingleton<IFaceClientServices>(new FaceClientServices(faceEndPoint,faceKey));
                    services.AddSingleton<IFaceServices, FaceServices>();
                    services.AddSingleton<IPasswordHasher, PasswordHasher>();
                    services.AddSingleton<ICourseServices, CourseServices>();
                    services.AddSingleton<IAccountService, AccountService>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<ILecturerService, LecturerServices>();
                    services.AddSingleton<IRegistrationService, RegistrationServices>();
                    services.AddSingleton<IStudentService, StudentSevices>();
                    services.AddSingleton<IStudentFaceService, StudentFaceService>();
                    services.AddSingleton<IAttendanceService, AttendanceService>();
                    services.AddSingleton<IStatisticsDataServices, StatisticsDataServices>();

                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddSingleton<IAccountStore, AccountStore>();
                    services.AddSingleton<IRoomServices, RoomServices>();


                    services.AddSingleton<AdminDashViewModel>();
                    services.AddSingleton<UserDashboardViewModel>();
                    services.AddSingleton<ProfileViewModel>();
                    services.AddSingleton<MAttendanceViewModel>();
                    services.AddSingleton<MLecturerViewModel>();
                    services.AddSingleton<AddLectuerViewModel>();
                    services.AddSingleton<LecturersViewModel>();

                    services.AddSingleton<MCourseViewModel>();
                    services.AddSingleton<CoursesViewModel>();
                    services.AddSingleton<AddCourseViewModel>();
                    
                    services.AddSingleton<ViewAttendanceViewModel>();
                    services.AddSingleton<TakeAttendanceViewModel>();
                    services.AddSingleton<RoomStatusViewModel>();
                    services.AddSingleton<LoginViewModel>();
                    services.AddSingleton<RegisterViewModel>();
                    services.AddSingleton<LogoutViewModel>();
                    services.AddSingleton<AddStudentViewModel>();
                    services.AddSingleton<AddFaceViewModel>();
                    services.AddSingleton<ModifyAttendanceViewModel>();
                    services.AddSingleton<StudentsViewModel>();




                    services.AddSingleton<CreateViewModel<AdminDashViewModel>>(services =>
                    {
                        return () => new AdminDashViewModel(services.GetRequiredService<IStatisticsDataServices>()
                            );
                    });

                    services.AddSingleton<CreateViewModel<LecturersViewModel>>(services =>
                    {
                        return () => new LecturersViewModel(services.GetRequiredService<ILecturerService>());
                    });
                    services.AddSingleton<CreateViewModel<AddLectuerViewModel>>(services =>
                    {
                        return () => new AddLectuerViewModel(services.GetRequiredService<ICourseServices>(), 
                            services.GetRequiredService<ILecturerService>());
                    });

                    services.AddSingleton<CreateViewModel<UserDashboardViewModel>>(services =>
                    {
                        return () => new UserDashboardViewModel(services.GetRequiredService<IStatisticsDataServices>(),
                            services.GetRequiredService<IAuthenticator>());
                    });

                    services.AddSingleton<CreateViewModel<ProfileViewModel>>(services =>
                    {
                        return () => new ProfileViewModel(
                            services.GetRequiredService<IAccountService>(),
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
                            );
                    });

                    services.AddSingleton<CreateViewModel<MAttendanceViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<MAttendanceViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<MLecturerViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<MLecturerViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<MCourseViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<MCourseViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<CoursesViewModel>>(services =>
                    {
                        return () => new CoursesViewModel(services.GetRequiredService<ICourseServices>());
                    });

                    services.AddSingleton<CreateViewModel<AddCourseViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<AddCourseViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<ViewAttendanceViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<ViewAttendanceViewModel>();
                    });

                    services.AddSingleton<CreateViewModel<TakeAttendanceViewModel>>(services =>
                    {
                        return () => new TakeAttendanceViewModel(
                            services.GetRequiredService<ICourseServices>(),
                            services.GetRequiredService<IStudentFaceService>(),
                            services.GetRequiredService<IAttendanceService>(),
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ILecturerService>()
                            );
                    });

                    services.AddSingleton<CreateViewModel<RoomStatusViewModel>>(services =>
                    {
                        return () => new RoomStatusViewModel(services.GetRequiredService<IRoomServices>());
                    });

                    services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                    {
                        return () => new LoginViewModel(services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<AdminDashViewModel>>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<UserDashboardViewModel>>()
                            );
                    });

                    services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<RegisterViewModel>();
                    });


                    services.AddSingleton<CreateViewModel<AddStudentViewModel>>(services =>
                    {
                        return () => new AddStudentViewModel(services.GetRequiredService<ICourseServices>(), 
                            services.GetRequiredService<IRegistrationService>());
                    });

                    services.AddSingleton<CreateViewModel<AddFaceViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<AddFaceViewModel>();
                    });
                    services.AddSingleton<CreateViewModel<StudentsViewModel>>(services =>
                    {
                        return () => new StudentsViewModel(services.GetRequiredService<IStudentService>());
                    });

                    services.AddSingleton<CreateViewModel<ModifyAttendanceViewModel>>(services =>
                    {
                        return () => new ModifyAttendanceViewModel(services.GetRequiredService<IAttendanceService>());
                    });

                    services.AddSingleton<CreateViewModel<LogoutViewModel>>(services =>
                    {
                        return () => new LogoutViewModel(services.GetRequiredService<IAccountService>(),
                            services.GetRequiredService<IAuthenticator>(),
                            services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
                            );

                    });


                    services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<AdminDashViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<UserDashboardViewModel>>();

                    services.AddSingleton<IViewModelFactory, ViewModelFactory>();
                    services.AddSingleton<IManageAttendanceViewModelFactory, ManageAttendanceViewModelFactory>();
                    services.AddSingleton<ICoursesViewModelFactory, CoursesViewModelFactory>();
                    services.AddSingleton<ILectuerViewModelFactory, LectuerViewModelFactory>();

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddScoped<MainViewModel>();
                    services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }

        protected override void OnStartup(StartupEventArgs args) {
            _host.Start();
            DatabaseContextFactory contextFactory = _host.Services.GetRequiredService<DatabaseContextFactory>();

            using (DatabaseContext context = contextFactory.CreateDbContext()) {
                    context.Database.Migrate();
            }

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(args);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

    }
}
