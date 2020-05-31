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
            return Ok(await hotelRoomRepository.GetHotelRooms(hotelId));
        }

        // GET: api/HotelRooms/5
        [HttpGet("{RoomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetoneHotelRoom(int hotelId, int roomNumber)
        {
            return Ok(await hotelRoomRepository.GetHotelRoomByNumber(hotelId, roomNumber));


        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{RoomNumber}")]
        public async Task<IActionResult> UpdateHotelRoom(int id, HotelRoom hotelRoom)
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
        [HttpPost("{RoomNumber}")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(int Id, int roomid, HotelRoom hotelRoom)
        {
            if (roomid != hotelRoom.Number)
            {
                return BadRequest();
            }

            bool updateComplete = await hotelRoomRepository.UpdateHotelRooms(Id, hotelRoom);

            if (!updateComplete)
            {
                return NotFound();
            }

            return NoContent();
        }



        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelRoomDTO>> DeleteHotelRoom(int id, int roomid)
        {
            var hotelRoom = await hotelRoomRepository.RemoveHotelRoom(id, roomid);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }
    }
}
