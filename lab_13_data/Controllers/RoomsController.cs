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
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRoom()
        {
            return Ok(await roomRepository.GetAllRooms());
          
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRoom(int id)
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

            //_context.Entry(room).State = EntityState.Modified;
            await roomRepository.UpdateRoom(id,room);

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RoomExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

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
        public async Task<ActionResult<Rooms>> DeleteRoom(int id)
        {
            
            var room= await roomRepository.DeleteRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            

            return room;
        }

        private bool RoomExists(int id)
        {
            //return _context.Room.Any(e => e.RoomId == id);
            return false;
        }
    }
}
