using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
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

        public async Task<AmenitiesDTO> DeleteAmenitie(int id)
        {
            var amenitie = await _context.Amenities.FindAsync(id);


            if (amenitie == null)
            {
                return null;
            }

            var amenitieToReturn = await GetOneAmenitie(id);

            _context.Amenities.Remove(amenitie);
            await _context.SaveChangesAsync();

            return amenitieToReturn;
        }

        public async Task<IEnumerable<AmenitiesDTO>> GetAllAmenities()
        {
            var amenities = await _context.Amenities

                .Select(amenities => new AmenitiesDTO
                {
                    Id = amenities.Id,
                    Name = amenities.Name,

                }).ToListAsync();

            return amenities;

        }

        public async Task<AmenitiesDTO> GetOneAmenitie(int id)
        {
            var amenities = await _context.Amenities
            .Select(amenities => new AmenitiesDTO
              {
                  Id = amenities.Id,
                  Name = amenities.Name,

              }).FirstOrDefaultAsync(amenitie => amenitie.Id == id);

            return amenities;
        }

        public async Task<AmenitiesDTO> SaveNewAmenitie(Amenities amenities)
        {
             _context.Amenities.Add(amenities);

            await _context.SaveChangesAsync();

            return await GetOneAmenitie(amenities.Id); 

        }

        public async Task<bool> UpdateAmenitie(int id, Amenities amenities)
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
        private bool AmenitiesExists(int  id)
        {
            return _context.Amenities.Any(e => e.Id == id);
           
        }
    }
}
