using Hostel.Models;
using Hostel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hostel.Pages
{


    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly HostelAllocationServices services;

        public IndexModel(ILogger<IndexModel> logger,UserManager<ApplicationUser> userManager,HostelAllocationServices services)
        {
            _logger = logger;
            this.userManager = userManager;
            this.services = services;
        }


        public bool IsExpired { get; set; }




        public double HoursLeft { get; set; } 
        [TempData]
        public string Message { get; set; }
        public  async Task OnGetAsync()
        {

          

            UpdateReservationTime();



              var user = await userManager.GetUserAsync(User);

            if(user.Email != "admin@yahoo.com")
            {

            }
            if (user.Reservation)
            {

                var currendate = DateTime.Now;
                var diff = currendate - user.ReservationTime;
                var hours = diff.TotalHours;

                //if (hours > 24)//if its more than 24 hours
                //{


                //    //first change the status of the room

                //    string roomNumber = user.RoomNumber;


                //    await services.UnReserveRoom(user.RoomIdForUser);
                //    // update the reservation code and other db field
                //    user.ReservationCode = string.Empty;
                //    user.Reservation = false;
                //    user.ReservationTime = new DateTime();
                //    user.BlockName = string.Empty;
                //    user.RoomNumber = string.Empty;

                //    user.RoomIdForUser = 0;



                //    await userManager.UpdateAsync(user);


                //    //we also have to update the the in the rooms table

                 


                
                //    IsExpired = true;
                //    Message = "Has Expired";
                //}

                Message = "Some Hours Remaining";

                HoursLeft = 24 - Math.Round( hours);

            }
            else
            {
                Message = "You dont have reservation";
            }


        }


        async void UpdateReservationTime()
        {
            var user = await userManager.GetUserAsync(User);

            user.ReservationTime = new DateTime(2021, 3, 1);
             await   userManager.UpdateAsync(user);
        }
    }
}
