
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

            modelBuilder.Entity<Hotels>()
               .HasData(
               new Hotels {Id=1 , Name= "mercure", StreetName= "progress st" , City="north liberty"},
               new Hotels { Id = 2, Name = "hilton", StreetName = "marylyn dr ", City = "north liberty" },
               new Hotels { Id = 3, Name = "azure", StreetName = "H st", City = "north liberty" }

               );

            modelBuilder.Entity<Amenities>()
                .HasData(
                new Amenities {Id=1,Name="tv" },
                new Amenities { Id = 2, Name = "toaster" },
                new Amenities { Id = 3, Name = "hair dryer" }

                );

            modelBuilder.Entity<RoomAmenities>()
               .HasData(
               new RoomAmenities { RoomId = 1, AmenitiesId = 1 },
               new RoomAmenities { RoomId = 1, AmenitiesId = 2 },
               new RoomAmenities { RoomId = 1, AmenitiesId = 3 },
               new RoomAmenities { RoomId = 2, AmenitiesId = 1 }

               );

            modelBuilder.Entity<Rooms>()
               .HasData(
               new Rooms{  Id = 1,  RoomName = "red"},
               new Rooms { Id = 2, RoomName = "bleu" },
               new Rooms { Id = 3, RoomName = "pink" },
               new Rooms { Id = 4, RoomName = "purple"}

               );

            modelBuilder.Entity<HotelRoom>()
               .HasData(
               new HotelRoom { HotelId =1 , RoomID= 1,  Number=250,Rate=9.5m, PetFrindly=false },
               new HotelRoom { HotelId = 1, RoomID = 2, Number = 20, Rate = 5m, PetFrindly = false },
               new HotelRoom { HotelId = 1, RoomID = 3, Number= 300, Rate =10m ,PetFrindly = false },
               new HotelRoom { HotelId = 2, RoomID = 4, Number = 250, Rate = 9.5m, PetFrindly = true }

               );
        }
        
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<Amenities> Amenities{ get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
