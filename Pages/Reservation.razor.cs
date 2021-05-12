using AntDesign;
using CurrieTechnologies.Razor.SweetAlert2;
using Hostel.Models;
using Hostel.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Pages
{
    public class ReservationBase : ComponentBase
    {
        protected List<Block> Blocks { get; set; }

        [Inject]
        public HostelAllocationServices Services { get; set; }
        [Inject]
        public NavigationManager Navigation{ get; set; }

        [Inject]
        public MessageService _message { get; set; }
        [Inject]
        public ConfirmService _confirmService { get; set; }

        [Inject]
        public ModalService _modalService { get; set; }

        public string ReservationCode { get; set; }

        //[Inject]
        //public SecondSevices SecondSevices { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public UserManager<ApplicationUser> UserManager { get; set; }

        public bool UserHasReservation { get; set; }

        public string UserReservationCode { get; set; }
        [Inject]
        public  SweetAlertService Swal { get; set; }

        public string Message { get; set; }


        protected void NavigateToPayment()
        {
            Navigation.NavigateTo("Payment",true);
        }

        protected async Task Sweet(int id)
        {
            // await Swal.FireAsync("Are you sure you want to Reserve this room?","Something",SweetAlertIcon.Question);


            var user = (await authenticationStateTask).User;


            var cUser = await UserManager.GetUserAsync(user);



            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Are you sure?",
                Text = "You will lose reservation If you dont pay within 24 hours!",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes, Reserve room!",
                CancelButtonText = "No, Don't reserve."
            });

            ReservationCode = RandomString(10);

            if (!string.IsNullOrEmpty(result.Value))
            {
                await Swal.FireAsync(
                  "Room Reserved ",
                  $"Your reservation code is {ReservationCode} .",
                  SweetAlertIcon.Success
                  );


                //update user reservation in the table


                UserHasReservation = true;
                UserReservationCode = ReservationCode;
                cUser.Reservation = true;
                cUser.ReservationCode = ReservationCode;
                cUser.ReservationTime = DateTime.Now;
                cUser.RoomIdForUser = id;
               




                Services.UpdateRservationCode(cUser.Id, ReservationCode, id);

                //await Services.UpdateRoom(id);

                StateHasChanged();


            }
            else if (result.Dismiss == DismissReason.Cancel)
            {
                await Swal.FireAsync(
                  "Cancelled",
                  "Your reservation was cancelled:)",
                  SweetAlertIcon.Error
                  );
            }
        }
        public List<Room> Rooms { get; set; }

        protected override async Task OnInitializedAsync()
        {


            var user = (await authenticationStateTask).User;


            var cUser = await UserManager.GetUserAsync(user);

            Blocks = (await Services.GetBlocksByGenderAsync(cUser.Gender)).ToList();


            IEnumerable<Block> test = from b in Blocks
                       from r in b.Rooms
                       where r.Reserved == false
                       select b;



            UserReservationCode = cUser.ReservationCode;
            UserHasReservation = cUser.Reservation;

            Message  = $"Your Reservation code :  {cUser.ReservationCode} reservation will last 24 hours.";


        }


        public async Task ChangeEvent(ChangeEventArgs e)
        {
            var user = (await authenticationStateTask).User;
            var cUser = await UserManager.GetUserAsync(user);

            int id = Convert.ToInt32(e.Value);
            Rooms = (await Services.GetHostelRoom(id)).ToList();




            StateHasChanged();

        }


        protected async Task ShowConfirm(ConfirmButtons confirmButtons)
        {
            var content = "Are Your Sure You want to reserve this room ?";
            var title = "Confirm Room";
            var confirmResult = await _confirmService.Show(content, title, confirmButtons);

            if (confirmResult != ConfirmResult.Yes)
            {
                var _ = _message.Info($"{confirmResult} button is clicked", 2);
            }
            else
            {
                ReservationCode = RandomString(10);


                var authenticationState = await authenticationStateTask;

                var user = (await authenticationStateTask).User;
                var cUser = await UserManager.GetUserAsync(user);


                //  Services.UpdateRservationCode(cUser.Id, ReservationCode);


                HandleSuccess();


            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private void HandleSuccess()
        {
            _modalService.Success(new ConfirmOptions()
            {
                Title = "Reservation Code",
                Content = $"A Reservation Code has been generated for you, The code is   {ReservationCode}"
            });
        }



        protected async Task ConfirmAsync(int Id)
        {
            ReservationCode = RandomString(10);


            var authenticationState = await authenticationStateTask;

            var user = (await authenticationStateTask).User;
            var cUser = await UserManager.GetUserAsync(user);


            Services.UpdateRservationCode(cUser.Id, ReservationCode, Id);


            HandleSuccess();
        }

        protected void Cancel()
        {
            _message.Error("Clicked on No");
        }

    }
}
