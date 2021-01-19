using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Models
{
    public class Block
    {
        public int Id { get; set; }
        public string BlockName { get; set; }
        public Gender BlockGender { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
