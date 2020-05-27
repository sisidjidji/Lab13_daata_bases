using lab_13_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetOneRoom(long id);

        Task<bool> UpdateRoom(long id ,Room room);
        Task<Room> SaveNewRoom(Room room);
        Task<Room> DeleteRoom(long id);
    }
}
