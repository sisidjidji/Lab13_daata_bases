
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab_13_data.Models.DTO_s;
using lab_13_data.Models;

namespace lab_13_data.Data.Repositories
{
    public class IHotelDatabaseRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public IHotelDatabaseRepository(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<HotelDTO> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
           

            if (hotel == null)
            {
                return null;
            }

            var HotelToReturn = await GetOneHotel(id);

            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();

            return HotelToReturn;

            
        }

        public async Task<IEnumerable<HotelDTO>> GetAllHotels()
        {
            var hotels = await _context.Hotels

                .Select(hotel => new HotelDTO
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetName,
                    City = hotel.City,
                    State = hotel.State,
                    Phone = hotel.Phone,


                    HotelRooms = hotel.Rooms
                        .Select(e => new HotelRoomDTO
                        {
                            HotelID = e.HotelId,
                            RoomNumber = e.Number,
                            Rate = e.Rate,
                            PetFriendly = e.PetFrindly,
                            RoomID = e.RoomID,

                            Room = new RoomDTO
                            {
                                ID = e.Room.Id,
                                Name = e.Room.RoomName,
                                Layout = e.Room.Layout.ToString(),
                                AmenitiesList = e.Room.Amenities
                                .Select(am => new AmenitiesDTO
                                {
                                    Id = am.Amenities.Id,
                                    Name = am.Amenities.Name
                                }).ToList()
                            }


                        }).ToList()

        }).ToListAsync();

            return hotels;
        }

        public async Task<HotelDTO> GetOneHotel(int id)
        {
                var hotel=await _context.Hotels

              .Select(hotel => new HotelDTO
              {
                  ID = hotel.Id,
                  Name = hotel.Name,
                  StreetAddress = hotel.StreetName,
                  City = hotel.City,
                  State = hotel.State,
                  Phone = hotel.Phone,

                  
                         HotelRooms = hotel.Rooms
                        .Select(e => new HotelRoomDTO
                        {
                            HotelID = e.HotelId,
                            RoomNumber = e.Number,
                            Rate = e.Rate,
                            PetFriendly = e.PetFrindly,
                            RoomID = e.RoomID,

                            Room = new RoomDTO
                            {
                                ID = e.Room.Id,
                                Name = e.Room.RoomName,
                                Layout = e.Room.Layout.ToString(),
                                AmenitiesList = e.Room.Amenities                               
                                .Select(am => new AmenitiesDTO
                               {
                                   Id = am.Amenities.Id,
                                   Name = am.Amenities.Name
                               }).ToList()
                            }

                        }).ToList()

              
              }).FirstOrDefaultAsync(hotel => hotel.ID == id);

            return hotel;
        }

        public async Task<HotelDTO> SaveNewHotel(Hotels hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return await GetOneHotel(hotel.Id); ;
        }

   

        public async Task<bool> UpdateHotel(int id, Hotels hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return false;
                }
                else
               {
                    throw;
               }
            }
        }

       

        private bool HotelExists(int id)
        {
            return _context.Hotels.Any(e => e.Id == id);

        }
    }
}
