using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Layout { get; set; }
        

      
    }
}
