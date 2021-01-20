using System.ComponentModel.DataAnnotations;

namespace Hostel.Models
{
    public class Room
    {
        public int Id { get; set; }
        [MaxLength(50)]

        public string RoomName { get; set; }

        [MaxLength(30)]

        public bool Occupied { get; set; } = false;
        public bool Reserved { get; set; } = false;
        public int BlockId { get; set; }
        public Block Block { get; set; }
    }
}