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

        public async Task<Rooms> DeleteRoom(long id)
        {
             var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<IEnumerable<Rooms>> GetAllRooms()
        {
             return await _context.Rooms.ToListAsync();
        }

        public async Task<Rooms> GetOneRoom(long id)
        {
            return await _context.Rooms.FindAsync(id);
            
        }

        public async  Task<Rooms> SaveNewRoom(Rooms room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return room;
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
