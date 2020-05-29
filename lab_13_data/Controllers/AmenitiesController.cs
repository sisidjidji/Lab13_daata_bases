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
    public class AmenitiesController : ControllerBase
    {
        
        IAmenitiesRepository amenitiesRepository;

        public AmenitiesController(IAmenitiesRepository amenitiesRepository)
        {
            this.amenitiesRepository = amenitiesRepository;
           
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenitiesDTO>>> GetAmenities()
        {
            
            return Ok( await amenitiesRepository.GetAllAmenities());
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenitiesDTO>> GetAmenities(int id)
        {
         
            var amenities = await amenitiesRepository.GetOneAmenitie(id);


            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(int id, Amenities amenities)
        {
           

            if (id != amenities.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await amenitiesRepository.UpdateAmenitie(id,amenities);

            if (!didUpdate)
            {
                return NotFound();
            }


            

            return NoContent();
        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AmenitiesDTO>> PostAmenities(Amenities amenities)
        {
           

            await amenitiesRepository.SaveNewAmenitie(amenities);

            return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AmenitiesDTO>> DeleteAmenities(int id)
        {
            

            var amenities = await amenitiesRepository.DeleteAmenitie(id);
            if (amenities == null)
            {
                return NotFound();
            }

           

            return amenities;
        }

        private bool AmenitiesExists(int id)
        {
            
            return false;
        }
    }
}
