using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public class RoomDatabaseRepository : IRoomRepository
    {
         private readonly HotelDbContext _context;
        public RoomDatabaseRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDTO> DeleteRoom(long id)
        { 
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            var roomToRemove = await GetOneRoom(id);

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return roomToRemove;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            var room = await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.RoomName,
                    Layout = room.Layout.ToString(),
                    AmenitiesList = room.Amenities
                    .Select(amenitie => new AmenitiesDTO
                    {
                        Id = amenitie.Id,
                        Name = amenitie.Name
                    }).ToList()

                }).ToListAsync();

            return room;
        }

        public async Task<RoomDTO> GetOneRoom(long id)
        {
            var room = await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.RoomName,
                    Layout = room.Layout.ToString(),

                    AmenitiesList = room.Amenities
                    .Select(amenitie => new AmenitiesDTO
                    {
                        Id = amenitie.Id,
                        Name = amenitie.Name
                    
                    }).ToList()

                }).FirstOrDefaultAsync(room => room.ID == id);

            return room;

        }

        public async  Task<RoomDTO> SaveNewRoom(Rooms room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return await GetOneRoom(room.Id);

        }

        public async Task<bool> UpdateRoom(long id, Rooms room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool RoomExists(long id)
        {
            return _context.Rooms.Any(e => e.Id == id);
            
        }
    }
}
