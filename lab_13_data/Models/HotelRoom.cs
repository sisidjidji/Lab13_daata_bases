using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab_13_data.Models
{
    public class HotelRoom
    {
        // PK (Composite) Key 1
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        // PK (Composite) Key 2
        public int Number { get; set; }

        // FK (Rooms)
        [Required]
        public Room Room { get; set; }

        [Column(TypeName = "money")]
        public decimal Rate { get; set; }

        public bool PetFrindly { get; set; }
    }
}
