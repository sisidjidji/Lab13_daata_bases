using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models
{
    public class HotelRoom
    {

        public int RoomNumber { get; set; }
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public decimal Rate { get; set; }
        public bool PetFrindly { get; set; }
    }
}
