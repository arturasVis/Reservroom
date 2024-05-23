using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModel
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        public string roomID => _reservation.roomID?.ToString();
        public string Username => _reservation.Username;
        public string StartTime => _reservation.StartTime.ToString("d");
        public string EndTime => _reservation.EndTime.ToString("d");

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;

            
        }
    }
}
