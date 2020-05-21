
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace lab_13_data.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext( DbContextOptions options) : base(options)
        {
        }
    }
}
