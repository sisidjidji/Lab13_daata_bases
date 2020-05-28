using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models.API
{
    public class HotelRoomApi
    {
        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public long RoomId { get; set; }
    }
}
