using lab_13_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
   public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<Hotel> GetOneHotel(long id);

        Task<bool> UpdateHotel(long id ,Hotel hotel);
        Task<Hotel> SaveNewHotel(Hotel hotel);
        Task<Hotel> DeleteHotel(long id);



    }
}
