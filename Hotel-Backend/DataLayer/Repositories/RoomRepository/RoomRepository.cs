using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories.RoomRepository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseContext DbContext;

        public RoomRepository(DatabaseContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<bool> DeleteRoom(int RoomNumber)
        {
            var Room = await DbContext.Rooms.FirstOrDefaultAsync(Room => Room.RoomNumber == RoomNumber);
            if (Room != null)
            {
                DbContext.Remove(Room);
                return  await DbContext.SaveChangesAsync() != 0;
            }
            return false;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await DbContext.Rooms.ToListAsync();
        }

        public async Task<bool> InsertRoom(Room HotelRoom)
        {
            DbContext.Add(HotelRoom);
            try
            {
                return await DbContext.SaveChangesAsync() != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRoom(Room HotelRoom)
        {
            var Room = await DbContext.Rooms.FirstOrDefaultAsync(Room => Room.RoomNumber == HotelRoom.RoomNumber);
            if (Room != null)
            {
                DbContext.Entry(Room).CurrentValues.SetValues(HotelRoom);
                return await DbContext.SaveChangesAsync() != 0;
            }
            return false;
        }
    }
}
