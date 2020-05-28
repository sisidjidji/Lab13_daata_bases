using lab_13_data.Models;
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

        public async Task<Room> DeleteRoom(long id)
        {
             var room = await _context.Room.FindAsync(id);
            _context.Room.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
             return await _context.Room.ToListAsync();
        }

        public async Task<Room> GetOneRoom(long id)
        {
            return await _context.Room.FindAsync(id);
            
        }

        public async  Task<Room> SaveNewRoom(Room room)
        {
            _context.Room.Add(room);
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task<bool> UpdateRoom(long id, Room room)
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
            return _context.Room.Any(e => e.RoomId == id);
            
        }
    }
}
