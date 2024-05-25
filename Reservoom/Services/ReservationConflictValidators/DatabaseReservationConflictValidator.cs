using Microsoft.EntityFrameworkCore;
using Reservoom.DbContexts;
using Reservoom.DTOS;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationConflictValidators
{
    public class DatabaseReservationConflictValidator : IReservationConflictValidator
    {
        private readonly ReservoomDbContextFactory _dbContextFactory;

        public DatabaseReservationConflictValidator(ReservoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation> GetConflictingReservation(Reservation reservation)
        {
            using (ReservoomDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO= await context.reservations
                    .Where(r => r.FloorNumber == reservation.roomID.FloorNumber)
                    .Where(r => r.RoomNumber == reservation.roomID.RoomNumber)
                    .Where(r => r.StartTime < reservation.EndTime)
                    .Where(r => r.EndTime > reservation.StartTime)
                    .FirstOrDefaultAsync();
                if (reservationDTO == null)
                {
                    return null;
                }
                return ToReservation(reservationDTO);

            }
        }

        private Reservation ToReservation(ReservationDTO r)
        {
            return new Reservation(new RoomID(r.FloorNumber, r.RoomNumber), r.StartTime, r.EndTime, r.Username);
        }
    }
}
