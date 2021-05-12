using Hostel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hostel.Data
{


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(9000);
        }

      



        public DbSet<Block> Blocks { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<TestStudent> TestStudents { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message),Microsoft.Extensions.Logging.LogLevel.Information);
           // optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information,);
          //  base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Block>().HasData(


               new Block
               {
                   Id = 1,
                   BlockName = "Block A",
                   BlockGender = Gender.Female,

               },

                new Block
                {
                    Id = 2,
                    BlockName = "Block B",
                    BlockGender = Gender.Female,

                },

                 new Block
                 {
                     Id = 3,
                     BlockName = "Block C",
                     BlockGender = Gender.Male,

                 },
                  new Block
                  {
                      Id = 4,
                      BlockName = "Block D",
                      BlockGender = Gender.Male,

                  }

               );


            builder.Entity<Room>().HasData(

                       new Room { Id = 1, RoomName = "Room 1", BlockId = 1 },
                       new Room { Id = 2, RoomName = "Room 2", BlockId = 1 },
                       new Room { Id = 3, RoomName = "Room 3", BlockId = 1 },
                       new Room { Id = 4, RoomName = "Room 4", BlockId = 1 },
                       new Room { Id = 5, RoomName = "Room 5", BlockId = 1 },
                       new Room { Id = 6, RoomName = "Room 6", BlockId = 1 },
                       new Room { Id = 7, RoomName = "Room 7", BlockId = 1 },
                       new Room { Id = 8, RoomName = "Room 8", BlockId = 1 },


                       new Room { Id = 9, RoomName = "Room 1", BlockId = 2 },
                       new Room { Id = 10, RoomName = "Room 2", BlockId = 2 },
                       new Room { Id = 11, RoomName = "Room 3", BlockId = 2 },
                       new Room { Id = 12, RoomName = "Room 4", BlockId = 2 },
                       new Room { Id = 13, RoomName = "Room 5", BlockId = 2 },
                       new Room { Id = 14, RoomName = "Room 6", BlockId = 2 },
                       new Room { Id = 15, RoomName = "Room 7", BlockId = 2 },
                       new Room { Id = 16, RoomName = "Room 8", BlockId = 2 },


                       new Room { Id = 17, RoomName = "Room 1", BlockId = 3 },
                       new Room { Id = 18, RoomName = "Room 2", BlockId = 3 },
                       new Room { Id = 19, RoomName = "Room 3", BlockId = 3 },
                       new Room { Id = 20, RoomName = "Room 4", BlockId = 3 },
                       new Room { Id = 21, RoomName = "Room 5", BlockId = 3 },
                       new Room { Id = 22, RoomName = "Room 6", BlockId = 3 },
                       new Room { Id = 23, RoomName = "Room 7", BlockId = 3 },
                       new Room { Id = 24, RoomName = "Room 8", BlockId = 3 },

                         new Room { Id = 25, RoomName = "Room 1", BlockId = 4 },
                       new Room { Id = 26, RoomName = "Room 2", BlockId = 4 },
                       new Room { Id = 27, RoomName = "Room 3", BlockId = 4 },
                       new Room { Id = 28, RoomName = "Room 4", BlockId = 4 },
                       new Room { Id = 29, RoomName = "Room 5", BlockId = 4 },
                       new Room { Id = 30, RoomName = "Room 6", BlockId = 4 },
                       new Room { Id = 31, RoomName = "Room 7", BlockId = 4 },
                       new Room { Id = 32, RoomName = "Room 8", BlockId = 4 }

           );
        }
    }
}
