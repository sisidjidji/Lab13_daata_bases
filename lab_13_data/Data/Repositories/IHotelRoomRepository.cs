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
       
            //POST
            Task<HotelRoomDTO> CreateHotelRoom(int hotelId, HotelRoom hotelRoomData);

            //GET

            Task<HotelRoomDTO> GetHotelRoomByNumber(int roomNumber, int hotelId);
            Task<IEnumerable<HotelRoomDTO>> GetHotelRooms(int hotelId);


            //UPDATE
            Task<bool> UpdateHotelRooms(int hotelId, HotelRoom hotelRoomData);


            // DELETE
            Task<HotelRoomDTO> RemoveHotelRoom(int roomNumber, int hotelId);   

    }
}
