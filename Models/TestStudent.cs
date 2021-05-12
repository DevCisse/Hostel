using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Models
{

    [Index(nameof(RegNo),IsUnique =true)]
    public class TestStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string RegNo { get; set; }
        public DateTime? Dob { get; set; }
    }
}
