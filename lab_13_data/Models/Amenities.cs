using System.ComponentModel.DataAnnotations;

namespace lab_13_data.Models
{
    public class Amenities
    {
        public int Id { get; set; }

        // Attribute
        [Required]
        public string Name { get; set; }

    }
}
