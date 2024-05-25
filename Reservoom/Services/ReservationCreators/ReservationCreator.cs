using Reservoom.DbContexts;
using Reservoom.DTOS;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationCreators
{
    public class ReservationCreator : IReservationCreator
    {
        private readonly ReservoomDbContextFactory _dbContextFactory;

        public ReservationCreator(ReservoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using(ReservoomDbContext context= _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.reservations.Add(reservationDTO);
                context.SaveChangesAsync();
            }
        }

        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                FloorNumber = reservation.roomID?.FloorNumber ?? 0,
                RoomNumber = reservation.roomID?.RoomNumber ?? 0,
                Username = reservation.Username,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime,
            };
        }
    }
}
