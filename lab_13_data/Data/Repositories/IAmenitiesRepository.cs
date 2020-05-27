using lab_13_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public interface IAmenitiesRepository
    {
        Task<IEnumerable<Amenities>> GetAllAmenities();
        Task<Amenities> GetOneAmenitie(long id);

        Task<bool> UpdateAmenitie(long id ,Amenities amenities);
        Task<Amenities> SaveNewAmenitie(Amenities amenities);
        Task<Amenities> DeleteAmenitie(long id);

    }
}
