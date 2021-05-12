using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Models
{
    public class Block
    {
        public int Id { get; set; }
        [MaxLength(50)]

        public string BlockName { get; set; }
        public Gender BlockGender { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
