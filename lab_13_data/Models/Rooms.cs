using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models
{
    public class Rooms
    {
        public int RoomId { get; set; }
        [Required]
        public string RoomName { get; set; }
        public RoomLayout Layout { get; set; }
        public List<Amenities> Amenities { get; set; }

    }

    public enum RoomLayout
    {
        Studio,
        TwoBedroom,
        threeBedroom
    }
}
        

      
    

