using lab_13_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Rooms>> GetAllRooms();
        Task<Rooms> GetOneRoom(long id);

        Task<bool> UpdateRoom(long id ,Rooms room);
        Task<Rooms> SaveNewRoom(Rooms room);
        Task<Rooms> DeleteRoom(long id);
    }
}
