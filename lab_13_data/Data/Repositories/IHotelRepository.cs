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
        Task<HotelDTO> GetOneHotel(int id);

        Task<bool> UpdateHotel(int id ,Hotels hotel);
        Task<HotelDTO> SaveNewHotel(Hotels hotel);
        Task<HotelDTO> DeleteHotel(int id);



    }
}
