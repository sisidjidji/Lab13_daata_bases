using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models
{
    public class HotelsDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string StreetName {get;set;}
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public List<HotelRoom> Rooms { get; set; }

    }
}
