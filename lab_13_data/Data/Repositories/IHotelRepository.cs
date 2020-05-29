using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
   public interface IHotelRepository
    {
        Task<IEnumerable<HotelDTO>> GetAllHotels();
        Task<HotelDTO> GetOneHotel(long id);

        Task<bool> UpdateHotel(long id ,Hotels hotel);
        Task<HotelDTO> SaveNewHotel(Hotels hotel);
        Task<HotelDTO> DeleteHotel(long id);



    }
}
