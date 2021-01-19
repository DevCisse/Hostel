namespace Hostel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int BlockId { get; set; }
        public Block Block { get; set; }
    }
}