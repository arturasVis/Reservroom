using Reservoom.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class ReservationBook
    {
        private readonly  List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations=new  List<Reservation>();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        public void AddReservation(Reservation reservation)
        {

            foreach(Reservation existingRes in _reservations)
            {
                if (existingRes.Conflicts(reservation))
                {
                    throw new ReservationConflictExeption(existingRes,reservation);
                }
            }
            _reservations.Add(reservation);
        }

    }
}
