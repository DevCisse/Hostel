using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hostel.Models;
using Hostel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Hostel.Pages
{

    [Authorize]
    public class PaymentModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly HostelAllocationServices services;

        public PaymentModel(UserManager<ApplicationUser> userManager,Hostel.Services.HostelAllocationServices services)
        {
            this.userManager = userManager;
            this.services = services;
        }

       
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";


        public string UserId { get; set; }
        //public void OnGet()
        //{


        //}

        public async Task<IActionResult> OnGetAsync()
        {


           
          

        // For ASP.NET Core <= 3.1
            ApplicationUser applicationUser = await userManager.GetUserAsync(User);
            Email = applicationUser.Email;

            //Email = "hassancisse2000@gmail.com";
            Email = applicationUser.Email;
            FirstName = applicationUser.FirstName;
            LastName = applicationUser.LastName;

            UserId = applicationUser.Id;

             return Page();

        
        }



        public JsonResult OnGetList()
        {
            List<string> lstString = new List<string>
            {
                "Val 1",
                "Val 2",
                "Val 3"
            };
            return new JsonResult(lstString);
        }



        public async Task<ActionResult> OnPostSendAsync()
        {

            ApplicationUser applicationUser = await userManager.GetUserAsync(User);
            string sPostValue1 = "";
            string sPostValue2 = "";
            string sPostValue3 = "";

            string reference = string.Empty;
            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);

                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<PData>(requestBody);
                        if (obj != null)
                        {
                       

                            reference = obj.Item1;

                        }
                    }
                }
            }


            services.UpdatePaymentDeatail(applicationUser.Id, reference);


            List<string> lstString = new List<string>
            {
                sPostValue1,
                sPostValue2,
                sPostValue3
            };
            return new JsonResult(lstString);


            

        }
    }


    class PData
    {
        public string Item1 { get; set; }
    }
}
