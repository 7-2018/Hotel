using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories.RoomRepository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();

        Task<bool> InsertRoom(Room HotelRoom);

        Task<bool> DeleteRoom(int RoomNumber);
        
        Task<bool> UpdateRoom(Room HotelRoom);
    }
}
