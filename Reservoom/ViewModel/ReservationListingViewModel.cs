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

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        private bool _isLoading;
        private string _errorMessage;
        
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasError));
            }
        }
        public bool HasError => !string.IsNullOrEmpty(_errorMessage);
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public MakeReservationViewModel MakeReservationViewModel { get; }
        public ICommand MakeReservationCommand { get; }
        public ICommand LoadReservationCommand { get; }
        HotelStore _hotelStore;
        public ReservationListingViewModel(HotelStore hotelStore, Services.NavigationService<MakeReservationViewModel> makeReservationnavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            LoadReservationCommand = new LoadReservationsCommand(hotelStore, this);
            MakeReservationCommand = new NavigateCommand<MakeReservationViewModel>(makeReservationnavigationService);

            _hotelStore = hotelStore;
            _hotelStore.ReservationMade += OnReservationMade;
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation); 
            _reservations.Add(reservationViewModel);
        }

        public static ReservationListingViewModel LoadViewModel(HotelStore _hotel, Services.NavigationService<MakeReservationViewModel> makeReservationnavigationService)
        {
            ReservationListingViewModel vm=new ReservationListingViewModel(_hotel,makeReservationnavigationService);

            vm.LoadReservationCommand.Execute(null);

            return vm;
        }
        public void UpdateReservations( IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();

            foreach(var item in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(item);
                _reservations.Add(reservationViewModel);
            }

        }

        public override void Dispose()
        {
            _hotelStore.ReservationMade -= OnReservationMade;
            base.Dispose();
        }
    }
}
