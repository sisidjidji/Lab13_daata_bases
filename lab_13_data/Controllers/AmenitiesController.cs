﻿using System;
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
    public class AmenitiesController : ControllerBase
    {
        // private readonly HotelDbContext _context;
        IAmenitiesRepository amenitiesRepository;

        public AmenitiesController(IAmenitiesRepository amenitiesRepository)
        {
            this.amenitiesRepository = amenitiesRepository;
            //_context = context;
        }

        // GET: api/Amenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAmenities()
        {
            // return await _context.Amenities.ToListAsync();
            return Ok( await amenitiesRepository.GetAllAmenities());
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenities(int id)
        {
            //var amenities = await _context.Amenities.FindAsync(id);
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


            //_context.Entry(amenities).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AmenitiesExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenities)
        {
            //_context.Amenities.Add(amenities);
            //await _context.SaveChangesAsync();

            await amenitiesRepository.SaveNewAmenitie(amenities);

            return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(int id)
        {
            // var amenities = await _context.Amenities.FindAsync(id);

            var amenities = await amenitiesRepository.DeleteAmenitie(id);
            if (amenities == null)
            {
                return NotFound();
            }

            //_context.Amenities.Remove(amenities);
            //await _context.SaveChangesAsync();

            return amenities;
        }

        private bool AmenitiesExists(int id)
        {
            //return _context.Amenities.Any(e => e.Id == id);
            return false;
        }
    }
}
