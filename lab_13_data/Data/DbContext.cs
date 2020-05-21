
using lab_13_data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace lab_13_data.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
