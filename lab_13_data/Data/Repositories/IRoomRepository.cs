using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomDTO>> GetAllRooms();
        Task<RoomDTO> GetOneRoom(long id);

        Task<bool> UpdateRoom(long id ,Rooms room);
        Task<RoomDTO> SaveNewRoom(Rooms room);
        Task<RoomDTO> DeleteRoom(long id);
    }
}
