using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public class HotelRoomDatabaseRepository : IHotelRoomRepository
    {
        public readonly HotelDbContext _context;

        public HotelRoomDatabaseRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Task<HotelRoomDTO> CreateHotelRoom(int hotelId, HotelRoom hotelRoomData)
        {
            throw new NotImplementedException();
        }

        public async Task<HotelRoomDTO> GetHotelRoomByNumber(int roomNumber, int hotelId)
        {

            var hotelRoom = await _context.HotelRoom
                .Where(hr => hr.HotelId == hotelId)
                .Where(hr => hr.Number == roomNumber)
                .Select(hr => new HotelRoomDTO
                {
                    HotelID = hr.HotelId,
                    RoomNumber = hr.Number,
                    Rate = hr.Rate,
                    Room = new RoomDTO
                    {
                        ID = hr.Room.Id,
                        Name = hr.Room.RoomName,
                        Layout = hr.Room.Layout.ToString(),

                        AmenitiesList = hr.Room.Amenities
                            .Select(ra => new AmenitiesDTO
                            {
                                Id = ra.Amenities.Id,
                                Name = ra.Amenities.Name,
                            })
                            .ToList(),
                    }
                }).FirstOrDefaultAsync();

            return hotelRoom;
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetHotelRooms(int hotelId)
        {

            var hotelrooms = await _context.HotelRoom

                .Where(hr => hr.HotelId == hotelId)

                .Select(hr => new HotelRoomDTO
                {

                    RoomNumber = hr.Number,
                    Rate = hr.Rate,
                    Room = new RoomDTO
                    {
                        ID = hr.Room.Id,
                        Name = hr.Room.RoomName,
                        Layout = hr.Room.Layout.ToString(),
                        AmenitiesList = hr.Room.Amenities
                        .Select(amenities => new AmenitiesDTO
                        {
                            Id = amenities.Amenities.Id,
                            Name = amenities.Amenities.Name

                        }).ToList()

                    }
                }).ToListAsync();

            return hotelrooms;
        }

        public Task<HotelRoomDTO> RemoveHotelRoom(int roomNumber, int hotelId)
        {
            
        }

        public Task<bool> UpdateHotelRooms(int hotelId, HotelRoom hotelRoomData)
        {
            throw new NotImplementedException();
        }
    }
}
