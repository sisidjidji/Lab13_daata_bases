using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public interface IAmenitiesRepository
    {
        Task<IEnumerable<AmenitiesDTO>> GetAllAmenities();
        Task<AmenitiesDTO> GetOneAmenitie(int id);
        Task<bool> UpdateAmenitie(int id ,Amenities amenities);
        Task<AmenitiesDTO> SaveNewAmenitie(Amenities amenities);
        Task<AmenitiesDTO> DeleteAmenitie(int id);

    }
}
