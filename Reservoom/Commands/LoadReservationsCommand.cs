using Reservoom.Models;
using Reservoom.Stores;
using Reservoom.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly HotelStore _hotel;
        private readonly ReservationListingViewModel _viewModel;

        public LoadReservationsCommand(HotelStore hotel, ReservationListingViewModel viewModel)
        {
            _hotel = hotel;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.ErrorMessage = string.Empty;
            _viewModel.IsLoading = true;
            try
            {
                await _hotel.Load();
                _viewModel.UpdateReservations(_hotel.Reservations);
            }
            catch (Exception)
            {
                _viewModel.ErrorMessage=_viewModel.ErrorMessage = "Failed to load reservations";
            }
            _viewModel.IsLoading = false;

        }
    }
}
