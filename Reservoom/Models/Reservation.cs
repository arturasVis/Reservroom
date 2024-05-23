using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID roomID { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Lenght => EndTime.Subtract(StartTime);
        public Reservation(RoomID roomID, DateTime startTime, DateTime endTime, string username)
        {
            this.roomID = roomID;
            StartTime = startTime;
            EndTime = endTime;
            Username = username;

        }

        internal bool Conflicts(Reservation reservation)
        {
            if (reservation.roomID != roomID) { return false; }
            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}
