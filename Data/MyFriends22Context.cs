using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFriends22.Models;

namespace MyFriends22.Data
{
    public class MyFriends22Context : DbContext
    {
        public MyFriends22Context (DbContextOptions<MyFriends22Context> options)
            : base(options)
        {
        }

        public DbSet<MyFriends22.Models.ImageModel> ImageModel { get; set; } = default!;
        public DbSet<MyFriends22.Models.FriendModel> FriendModel { get; set; } = default!;
    }
}
