
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>()
                .HasKey(hotelRoom => new
                {
                    hotelRoom.HotelId,
                    hotelRoom.Number,
                }
                );

            modelBuilder.Entity<RoomAmenities>()
                .HasKey(roomAmenities => new
                {
                    roomAmenities.AmenitiesId,
                    roomAmenities.RoomId,
                }
                );
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Amenities> Amenities{ get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
