using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservoom.DbContexts;
using Reservoom.Exeptions;
using Reservoom.HostBuilders;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Services.ReservationConflictValidators;
using Reservoom.Services.ReservationCreators;
using Reservoom.Services.ReservationProviders;
using Reservoom.Stores;
using Reservoom.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;

namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host= Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((hostContext,services) =>
            {
                string connectionString=hostContext.Configuration.GetConnectionString("Default");
                
                services.AddSingleton(new ReservoomDbContextFactory(connectionString));
                services.AddSingleton<IReservationProvider,DatabaseReservationProvider>();
                services.AddSingleton<IReservationCreator, ReservationCreator>();
                services.AddSingleton<IReservationConflictValidator, DatabaseReservationConflictValidator>();

                services.AddTransient<ReservationBook>();
                services.AddSingleton((s) => new Hotel("Arturas Hotel",s.GetRequiredService<ReservationBook>()) );



                services.AddSingleton<NavigationService<ReservationListingViewModel>>();
                services.AddSingleton<NavigationService<MakeReservationViewModel>>();

                services.AddSingleton<HotelStore>();
                services.AddSingleton<NavigationStore>();

                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                    
                }) ;
            })
                .Build();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            ReservoomDbContextFactory reservoomDbContextFactory=_host.Services.GetRequiredService<ReservoomDbContextFactory>();
            using (ReservoomDbContext reservoomDbContect = reservoomDbContextFactory.CreateDbContext())
            {
                reservoomDbContect.Database.Migrate();
            }

            NavigationService<ReservationListingViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<ReservationListingViewModel>>();
            navigationService.Navigate();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }

}
