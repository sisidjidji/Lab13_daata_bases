using lab_13_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace lab_13_data.Data.Repositories
{
    public class HotelDatabaseRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelDatabaseRepository(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> DeleteHotel(long id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);

            return hotel;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetOneHotel(long id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public async  Task<Hotel> SaveNewHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<bool> UpdateHotel(long id,Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return false;
                }
                else
               {
                    throw;
               }
            }
        }

        private bool HotelExists(long id)
        {
            return _context.Hotels.Any(e => e.Id == id);

        }
    }
}
