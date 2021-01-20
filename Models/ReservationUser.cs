using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Models
{
    public class ReservationUser
    {

        [Key]
        [ForeignKey("AspnetUsersId")]
        public string Id { get; set; }
        public int RoomNumber { get; set; }
        public bool Reservation { get; set; } = false;
        public bool Occupied { get; set; } = false;

        public virtual IdentityUser Identity { get; set; }
    }
}
