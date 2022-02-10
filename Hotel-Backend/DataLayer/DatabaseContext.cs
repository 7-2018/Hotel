using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Guest> Guests { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Receptionist> Receptionists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(c => new { c.GuestID, c.HotelRoomNumber, c.CheckInDate });
        }


    }
}
