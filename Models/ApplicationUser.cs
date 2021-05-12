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
        [MaxLength(50)]
        [Display(Name = "First Name is required")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name is required")]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [MaxLength(50)]

        public string ReservationCode { get; set; }

        public bool Reservation { get; set; } = false;

        public DateTime ReservationTime { get; set; }

        [MaxLength(50)]

        public string BlockName { get; set; }
        public string RoomNumber { get; set; }

        public int RoomIdForUser { get; set; }
        [Required]
        [MaxLength(50)]

        public string AdmissionNumber { get; set; }
        [MaxLength(50)]

        public string State { get; set; }
        [MaxLength(50)]

        public string Lga { get; set; }

        public DateTime PaymentTime { get; set; }
        public decimal AmountPayed { get; set; }
        public string PaymentCode { get; set; }

    }
}
