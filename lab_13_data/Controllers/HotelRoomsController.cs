using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab_13_data.Data;
using lab_13_data.Models;
using lab_13_data.Data.Repositories;
using lab_13_data.Models.DTO_s;

namespace lab_13_data.Controllers
{
   [Route("api /Hotels/{HotelId}/Rooms")]
   [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        IHotelRoomRepository hotelRoomRepository;

        public HotelRoomsController(IHotelRoomRepository hotelRoomrepository)
        {
            this.hotelRoomRepository = hotelRoomrepository;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRoom(int hotelId)
        {
            return  Ok(await hotelRoomRepository.GetHotelRooms(hotelId));
        }

        // GET: api/HotelRooms/5
        [HttpGet("{RoomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetoneHotelRoom(int hotelId , int roomNumber)
        {
            return Ok(await hotelRoomRepository.GetHotelRoomByNumber(hotelId, roomNumber));

           
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelRoom(int id , HotelRoom hotelRoom)
        {
            if (id != hotelRoom.Number)
            {
                return BadRequest();
            }

            bool updateComplete = await hotelRoomRepository.UpdateHotelRooms(id, hotelRoom);

            if (!updateComplete)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRoom.Add(hotelRoom);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelRoomExists(hotelRoom.HotelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int id)
        {
            var hotelRoom = await _context.HotelRoom.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            _context.HotelRoom.Remove(hotelRoom);
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        private bool HotelRoomExists(long id)
        {
            return _context.HotelRoom.Any(e => e.HotelId == id);
        }
    }
}
