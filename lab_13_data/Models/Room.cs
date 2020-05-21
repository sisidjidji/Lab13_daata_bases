using System.ComponentModel.DataAnnotations;

namespace lab_13_data.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        public string Name { get; set; }
        public RoomLayout Layout { get; set; }



    }

    public enum RoomLayout
    {
        Studio,
        TwoBedroom,
    }
}
