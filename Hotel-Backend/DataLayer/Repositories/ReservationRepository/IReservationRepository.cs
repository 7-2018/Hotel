using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.ReservationRepository
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();

        Task<bool> InsertReservation(Reservation HotelReservation);

        Task<bool> DeleteReservation(string GuestID, int HotelRoomNumber, DateTime CheckInDate);

        Task<bool> UpdateReservation(Reservation HotelReservation);
    }
}
