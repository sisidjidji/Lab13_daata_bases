using lab_13_data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public class AmenitiesDatabaseRepository : IAmenitiesRepository
    {
         private readonly HotelDbContext _context;

        public AmenitiesDatabaseRepository (HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Amenities> DeleteAmenitie(long id)
        {
             var amenities = await _context.Amenities.FindAsync(id);
            _context.Amenities.Remove(amenities);

            return amenities;
        }

        public async Task<IEnumerable<Amenities>> GetAllAmenities()
        {
            return  await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetOneAmenitie(long id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<Amenities> SaveNewAmenitie(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();

            return amenities;
        }

        public async Task<bool> UpdateAmenitie(long id, Amenities amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool AmenitiesExists(long  id)
        {
            return _context.Amenities.Any(e => e.Id == id);
           
        }
    }
}
