﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models.DTO_s
{
    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }
}
