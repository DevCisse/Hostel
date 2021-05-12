using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.DTO
{
    public class StudentDto
    {
        public string  Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string HasReservedRoom { get; set; }
        public string HasPaid { get; set; }
        public string State { get; set; }

        public string PaymentCode { get; set; }
        public decimal AmountPayed { get; set; }
        public string PaymentTime { get; set; }

        public string RoomNumber { get; set; }

    }
}
