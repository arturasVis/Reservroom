using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservoom.Services;
using Reservoom.Stores;
using Reservoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient((s) => CreateReservationViewModel(s));
                services.AddSingleton<Func<ReservationListingViewModel>>((s)
                    => () => s.GetRequiredService<ReservationListingViewModel>());

                services.AddTransient<MakeReservationViewModel>();
                services.AddSingleton<Func<MakeReservationViewModel>>((s)
                    => () => s.GetRequiredService<MakeReservationViewModel>());
                services.AddSingleton<MainViewModel>();
            });
            return hostBuilder;
        }

        private static ReservationListingViewModel CreateReservationViewModel(IServiceProvider s)
        {
            return ReservationListingViewModel.LoadViewModel(
                s.GetRequiredService<HotelStore>(),
                s.GetRequiredService<NavigationService<MakeReservationViewModel>>());
        }
    }
}
