using Microsoft.EntityFrameworkCore;
using Reservoom.DTOS;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DbContexts
{
    public class ReservoomDbContext : DbContext
    {
        public ReservoomDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ReservationDTO> reservations { get; set; }
    }
}
