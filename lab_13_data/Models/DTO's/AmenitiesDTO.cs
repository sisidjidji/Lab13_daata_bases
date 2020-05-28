using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data.Models.DTO_s
{
    public class AmenitiesDTO

    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
