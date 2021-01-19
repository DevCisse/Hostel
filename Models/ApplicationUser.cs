using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }

        public string ReservationCode { get; set; }
        public bool Reservation { get; set; }

        public DateTime ReservationTime { get; set; }

        public string BlockName { get; set; }
        public string RoomNumber { get; set; }

        public int RoomIdForUser { get; set; }
        [Required]
        public string AdmissionNumber { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }

    }
}
