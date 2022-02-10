using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAllGuests();

        Task<bool> InsertGuest(Guest HotelGuest);

        Task<bool> DeleteGuest(string ID);

        Task<bool> UpdateGuest(Guest HotelGuest);
    }
}
