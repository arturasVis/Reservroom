using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Exeptions
{
    public class ReservationConflictExeption : Exception
    {

        public Reservation existingReservation { get; }
        public Reservation incomingReservation { get; }

        public ReservationConflictExeption(Reservation existingReservation, Reservation incomingReservation)
        {
            this.existingReservation = existingReservation;
            this.incomingReservation = incomingReservation;
        }

        public ReservationConflictExeption(string? message, Reservation existingReservation, Reservation incomingReservation) : base(message)
        {
            this.existingReservation = existingReservation;
            this.incomingReservation = incomingReservation;
        }

        public ReservationConflictExeption(string? message, Exception? innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException)
        {
            this.existingReservation = existingReservation;
            this.incomingReservation = incomingReservation;
        }
    }
}
