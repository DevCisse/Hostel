using Hostel.Data;
using Hostel.DTO;
using Hostel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel.Services
{
    public class HostelAllocationServices
    {
        private readonly ApplicationDbContext context;

        public HostelAllocationServices(ApplicationDbContext context)
        {
            this.context = context;
        }



        public async Task<List<BlockRooms>> GetBlockRoomsAsync()
        {

            var res = await context.Rooms.Include(x => x.Block).ToListAsync();
            List<BlockRooms> blockRooms = new List<BlockRooms>();

            foreach (var item in res)
            {
                BlockRooms blockrm = new BlockRooms
                {
                    Id = item.Id,
                    RoomName = item.RoomName,
                    Occupied = item.Occupied.ToString(),
                    Reserved = item.Reserved.ToString(),
                    BlockName = item.Block.BlockName,
                    Gender = item.Block.BlockGender.ToString()
                };

                blockRooms.Add(blockrm);
            }

            return blockRooms;
        }
        public async Task<List<Block>> GetBlockAsync()
        {

           
            return await context.Blocks.ToListAsync();
        }

        public async Task<Room> UpdateRoom(int id)
        {
            var room = context.Rooms.Where(x => x.Id ==id).First();
            room.Reserved = true;
            await context.SaveChangesAsync();

            return room;

        }
        public async Task<Room> UnReserveRoom(int id)
        {
            var room = context.Rooms.Where(x => x.Id == id).First();
            room.Reserved = false;
            await context.SaveChangesAsync();

            return room;

        }


        public async Task<List<Block>> GetBlocksByGenderAsync(Gender gender)
        {

            //var t =await (from b in context.Blocks
            //        from r in b.Rooms
            //        where b.BlockGender == gender
            //        where r.Reserved == false
            //        select b).ToListAsync();

            //var u = await (from b in context.Blocks
            //        from r in b.Rooms
            //        where b.BlockGender == gender
            //        select b).ToListAsync();

            ////var uu = from b in context.Blocks.Include(x=>x.Rooms)
            //         where b.





            //var test = from b in context.Blocks
            //           from r in b.Rooms.Where(x=>x.Reserved == false)
                       
              var res =  await context.Blocks.Where(x => x.BlockGender == gender).Include(x=> x.Rooms.Where(x=>x.Reserved == false)).ToListAsync();


            string st = context.Blocks.Where(x => x.BlockGender == gender).Include(x => x.Rooms.Where(x => x.Reserved == false)).ToQueryString();


  
            return res;

          //  return u;

        }


        public async Task<IEnumerable<Room>> GetHostelRoom(int id)
        {
            var result = await context.Rooms.Where(x => x.BlockId == id && x.Reserved == false).ToListAsync() ;

            var tostring = result.ToString();
            Console.WriteLine(tostring);

            return result;
        }


        public async Task<IEnumerable<Room>> GetHostelRooms() => await context.Rooms.Include(x=>x.Block).ToListAsync();



        public void UpdateRservationCode(string userId, string code, int roomNumber)
        {
            //var user = context.Users.FirstOrDefault(x => x.Id == userId);
            //user.ReservationCode = code;
            //user.ReservationTime = DateTime.Now;
            //user.Reservation = true;
            //user.RoomNumber = roomNumber.ToString();


            //var rb = context.Rooms.Where(x => x.Id == roomNumber).SingleOrDefault();
            //user.BlockName = rb.Block.BlockName;
            //context.SaveChanges();


            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            user.ReservationCode = code;
            user.ReservationTime = DateTime.Now;
            user.Reservation = true;
            user.RoomNumber = roomNumber.ToString();


            var rb = context.Rooms.Where(x => x.Id == roomNumber).SingleOrDefault();
            user.BlockName = rb.Block.BlockName;



            var rm  = context.Rooms.First(x => x.Id == roomNumber);
            rm.Reserved = true;

            context.SaveChanges();

        }



        public void UpdatePaymentDeatail(string userId,string paymentCode)
        {
            var user = context.Users.First(x => x.Id == userId);

            user.AmountPayed = 10000M;
            user.PaymentCode = paymentCode;
            user.PaymentTime = DateTime.Now;

            context.SaveChanges();
            

        }


    }
}
