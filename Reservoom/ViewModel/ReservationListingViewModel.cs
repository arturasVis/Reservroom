using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModel
{
    public class ReservationListingViewModel : ViewModelBase
    {

        private readonly ObservableCollection<ReservationViewModel> _reservations;
        private readonly Func<ViewModelBase> createViewModel;
        private readonly Hotel hotel;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand MakeReservationCommand { get; }
        public ReservationListingViewModel(Hotel _hotel, Services.NavigationService makeReservationnavigationService)
        {
            hotel = _hotel;
            _reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(makeReservationnavigationService);

            UpdateReservations();
            
        }

        private void UpdateReservations()
        {
            _reservations.Clear();

            foreach(var item in hotel.GetAllReservations())
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(item);
                _reservations.Add(reservationViewModel);
            }

        }
    }
}
