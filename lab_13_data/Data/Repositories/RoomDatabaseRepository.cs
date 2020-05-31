using lab_13_data.Models;
using lab_13_data.Models.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Data.Repositories
{
    public class RoomDatabaseRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;
        public RoomDatabaseRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDTO> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            var roomToRemove = await GetOneRoom(id);

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return roomToRemove;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            var room = await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.RoomName,
                    Layout = room.Layout.ToString(),
                    AmenitiesList = room.Amenities
                    .Select(amenitie => new AmenitiesDTO
                    {
                        Id = amenitie.Amenities.Id,
                        Name = amenitie.Amenities.Name
                    }).ToList()

                }).ToListAsync();

            return room;
        }

        public async Task<RoomDTO> GetOneRoom(int id)
        {
            var room = await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.RoomName,
                    Layout = room.Layout.ToString(),

                    AmenitiesList = room.Amenities
                    .Select(amenitie => new AmenitiesDTO
                    {
                        Id = amenitie.Amenities.Id,
                        Name = amenitie.Amenities.Name

                    }).ToList()

                }).FirstOrDefaultAsync(room => room.ID == id);

            return room;

        }

        public async Task<RoomDTO> SaveNewRoom(Rooms room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return await GetOneRoom(room.Id);

        }

        public async Task<bool> UpdateRoom(int id, Rooms room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool RoomExists(long id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        public async Task AddAmenityToRoom(int amenityId, int roomId)
        {
            var roomAmenity = new RoomAmenities
            {
                AmenitiesId = amenityId,
                RoomId = roomId,
            };
            _context.RoomAmenities.Add(roomAmenity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int amenityId, int roomId)
        {
            var roomAmenity = await _context.RoomAmenities
                .Where(ra => ra.AmenitiesId == amenityId)
                .Where(ra => ra.RoomId == roomId)
                .FirstOrDefaultAsync();

            if (roomAmenity != null)
            {
                _context.RoomAmenities.Remove(roomAmenity);
                await _context.SaveChangesAsync();
            }
        }
    }
}