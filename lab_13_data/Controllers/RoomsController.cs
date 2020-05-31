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
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        IRoomRepository roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRoom()
        {
            return Ok(await roomRepository.GetAllRooms());

        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {

            var room = await roomRepository.GetOneRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Rooms room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            await roomRepository.UpdateRoom(id, room);

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rooms>> PostRoom(Rooms room)
        {
            await roomRepository.SaveNewRoom(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomDTO>> DeleteRoom(int id)
        {

            var room = await roomRepository.DeleteRoom(id);

            if (room == null)
            {
                return NotFound();
            }



            return room;
        }

        private bool RoomExists(int id)
        {
            
            return false;
        }


        //Post:api/Room/7/Amenity/2
        [HttpPost("{roomId}/Amenities/{amenityId}")]
        public async Task<ActionResult> AddRoomAmenity(int roomId, int amenityId)
        {
            await roomRepository.AddAmenityToRoom(amenityId, roomId);
            return NoContent();
        }

        // DELETE: api/Rooms/5/Amenities/17
        [HttpDelete("{roomId}/Amenities/{amenityId}")]
        public async Task<ActionResult> RemoveRoomAmenity(int roomId, int amenityId)
        {
            await roomRepository.RemoveAmenityFromRoom(amenityId, roomId);
            return NoContent();
        }
    }
}