using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DatabaseContext DbContext;

        public GuestRepository(DatabaseContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<bool> DeleteGuest(string ID)
        {
            var Guest = await DbContext.Guests.FirstOrDefaultAsync(Guest => Guest.ID == ID);
            if (Guest != null)
            {
                DbContext.Remove(Guest);
                return await DbContext.SaveChangesAsync() != 0;
            }
            return false;
        }

        public async Task<IEnumerable<Guest>> GetAllGuests()
        {
            return await DbContext.Guests.ToListAsync();
        }

        public async Task<bool> InsertGuest(Guest HotelGuest)
        {
            DbContext.Add(HotelGuest);
            try
            {
                return await DbContext.SaveChangesAsync() != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGuest(Guest HotelGuest)
        {
            var Guest = await DbContext.Guests.FirstOrDefaultAsync(Guest => Guest.ID == HotelGuest.ID);
            if (Guest != null)
            {
                DbContext.Entry(Guest).CurrentValues.SetValues(HotelGuest);
                return await DbContext.SaveChangesAsync() != 0;
            }
            return false;
        }
    }
}
