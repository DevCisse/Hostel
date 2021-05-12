using Hostel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.DTO
{
    public class BlockRooms
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Occupied { get; set; }
        public string Reserved { get; set; }
        public string BlockName { get; set; }

        public string Gender{ get; set; }
    }
}
