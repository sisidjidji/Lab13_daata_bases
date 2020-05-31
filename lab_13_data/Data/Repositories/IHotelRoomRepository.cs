using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public interface IHotelRoomRepository
    {
       
         
            Task<HotelRoomDTO> CreateHotelRoom(int hotelId, HotelRoom hotelRoomData);

            Task<HotelRoomDTO> GetHotelRoomByNumber(int roomNumber, int hotelId);
            Task<IEnumerable<HotelRoomDTO>> GetHotelRooms(int hotelId);

            Task<bool> UpdateHotelRooms(int hotelId, HotelRoom hotelRoomData);

            Task<HotelRoomDTO> RemoveHotelRoom(int roomNumber, int hotelId);   

    }
}
