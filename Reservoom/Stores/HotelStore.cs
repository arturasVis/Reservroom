using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Stores
{
    public class HotelStore
    {

        private readonly List<Reservation> _reservations;
        private readonly Hotel hotel;
        private Lazy<Task> _initializeLazy;

        public IEnumerable<Reservation> Reservations => _reservations;
        public event Action<Reservation> ReservationMade;
        public HotelStore(Hotel hotel)
        {
             _reservations = new List<Reservation>();
            this.hotel = hotel;
            _initializeLazy = new Lazy<Task>(Initialize());
        }

        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
            }
            catch (Exception)
            {
                _initializeLazy=new Lazy<Task>(Initialize);
                throw;
            }
            
        }
        public async Task MakeReservation(Reservation reservation)
        {
            await hotel.MakeReservatio(reservation);

            _reservations.Add(reservation);

            OnReservationMade(reservation);
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationMade?.Invoke(reservation);
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await hotel.GetAllReservations();

            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
