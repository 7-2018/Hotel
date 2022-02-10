using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DatabaseContext DbContext;

        public ReservationRepository(DatabaseContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<bool> DeleteReservation(string GuestID, int HotelRoomNumber, DateTime CheckInDate)
        {
            var Reservation = await DbContext.Reservations.FirstOrDefaultAsync(Reservation =>
            Reservation.GuestID == GuestID &&
            Reservation.HotelRoomNumber == HotelRoomNumber &&
            Reservation.CheckInDate == CheckInDate);
            if (Reservation != null)
            {
                DbContext.Remove(Reservation);
                return await DbContext.SaveChangesAsync() != 0;
            }
            return false;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await DbContext.Reservations.ToListAsync();
        }

        public async Task<bool> InsertReservation(Reservation HotelReservation)
        {
            DbContext.Add(HotelReservation);
            try
            {
                return await DbContext.SaveChangesAsync() != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateReservation(Reservation HotelReservation)
        {
            var Reservation = await DbContext.Reservations.FirstOrDefaultAsync(Reservation =>
            Reservation.GuestID == HotelReservation.GuestID &&
            Reservation.HotelRoomNumber == HotelReservation.HotelRoomNumber &&
            Reservation.CheckInDate == HotelReservation.CheckInDate);
            if (Reservation != null)
            {
                DbContext.Entry(Reservation).CurrentValues.SetValues(HotelReservation);
                return await DbContext.SaveChangesAsync() != 0;
            }
            return false;
        }
    }
}
