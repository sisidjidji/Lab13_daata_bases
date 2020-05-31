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
        Task<RoomDTO> GetOneRoom(int id);
        Task<bool> UpdateRoom(int id ,Rooms room);
        Task<RoomDTO> SaveNewRoom(Rooms room);
        Task<RoomDTO> DeleteRoom(int id);
        Task AddAmenityToRoom(int amenityId, int roomId);
        Task RemoveAmenityFromRoom(int amenityId, int roomId);
    }
}
