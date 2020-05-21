using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models
{
    public class RoomAmenities
    {
        public int  AmenitiesId { get; set; }
        public int RoomId { get; set; }
        public Amenities Amenities { get; set; }
      public Room Room { get; set; }
    }
}
