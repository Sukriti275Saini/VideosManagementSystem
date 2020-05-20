using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideosManagementSystem.Core;

namespace VideosManagementSystem.Data
{
    public class VMSDbContext : DbContext
    {
        public VMSDbContext(DbContextOptions<VMSDbContext> options) : base(options)
        {

        }
        public DbSet<Blogs> Blog { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Users> User { get; set; }

        public DbSet<Videos> Video { get; set; }

        public DbSet<UsersVideoRecord> Records { get; set; }

    }
}
