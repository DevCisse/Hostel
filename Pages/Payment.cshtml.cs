using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Hostel.Pages
{
    public class PaymentModel : PageModel
    {
        public string Email { get; set; } = "hassancisse2000@gmail.com";
        public string FirstName { get; set; } = "Salihu";
        public string LastName { get; set; } = "Hassan";
        public void OnGet()
        {
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



        public ActionResult OnPostSend()
        {
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
