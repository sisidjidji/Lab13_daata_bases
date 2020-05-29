using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }



        [Required]
        public Rooms Room { get; set; }
        public HotelsDTO Hotel { get; set; }
        public decimal Rate { get; set; }
        public bool PetFrindly { get; set; }
        public int Number { get; set; }
    }
}
