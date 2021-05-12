using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hostel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostel.Pages
{

    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProfileModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public string Id { get; set; }
        public async Task OnGet()
        {
            //var user = User;

            //Email = user.Identity.Name;
            //InputModel model = new InputModel
            //{
            //    Email = user.Identity.Name
            //};


            var user  = await userManager.GetUserAsync(User);

           

            Input.FirstName = user.FirstName;
            Input.LastName = user.LastName;

           
          

        
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string Email { get; set; }


        public class InputModel
        {

           
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);

                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;

                var result = await userManager.UpdateAsync(user);

                return  RedirectToPage("/Index");
            }

            return Page();



          
        }
    }
}
