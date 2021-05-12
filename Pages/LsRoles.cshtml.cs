using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hostel.Pages
{
    public class LsRolesModel : PageModel
    {


        public List<IdentityRole> RolesList{ get; set; }
        //public LsRolesModel(RoleManager<IdentityRole> roleManager)
        //{
        //    this.roleManager = roleManager;

        //}

        private readonly RoleManager<IdentityRole> roleManager;

        public LsRolesModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public void OnGet()
        {

            var list = roleManager.Roles;

            if(list != null)
            {
               
               
            }
            
        }
    }
}
