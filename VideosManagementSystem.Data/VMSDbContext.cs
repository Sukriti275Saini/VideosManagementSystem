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

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Users>()
              .HasData(new
              {
                  UserName = "Sukriti275Saini",
                  FullName = "Sukriti Saini",
                  ProfilePicture = "",
                  DateOfBirth = new DateTime(1995, 05, 27),
                  Email = "s@s.in",
                  Password = "Saini123",
                  PhoneNo = 7418529630,
                  Address = "Pathankot"

              });


            bldr.Entity<Videos>()
              .HasData(new
              {
                  VideoId = 1,
                  VideoName = "Corona ka rona",
                  YearOfRelease = 2020,
                  Language = "Chinese",
                  Director = "China",
                  Actor = "COVID-19",
                  Description = "MKC Corona ki",
                  NoOfCopies = 2,
                  LeaseAmount = 200,
                  VideoImage = ""
              });
              }
        /*, new
              {
                  MoviesId = 2,
                  Title = "Avengers: Age Of Ultron",
                  Director = "Josan",
                  Language = "English",
                  Genre = "Thriller",
                  ReleaseYear = 2012,
                  Description = "Tony Stark builds an artificial intelligence system named Ultron with the help of Bruce Banner. And when things go wrong, it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                  ReturnDays = 25,
                  Fine = 700,
              }, new
              {
                  MoviesId = 3,
                  Title = "Avengers: Infinity War",
                  Director = "Marvels",
                  Language = "Hindi",
                  Genre = "Action",
                  ReleaseYear = 2018,
                  Description = "With the powerful Thanos on the verge of raining destruction upon the universe, the Avengers and their Superhero allies risk everything in the ultimate showdown of all time.",
                  ReturnDays = 20,
                  Fine = 800,
              });

            bldr.Entity<Records>()
              .HasData(new
              {
                  RecordsId = 1,
                  UserName = "surisagar900",
                  MoviesId = 1,
                  TakenDate = new DateTime(2020, 05, 04),
                  ReturnDate = new DateTime(2020, 05, 24)
              },
              new
              {
                  RecordsId = 2,
                  UserName = "surisagar900",
                  MoviesId = 3,
                  TakenDate = new DateTime(2020, 05, 02),
                  ReturnDate = new DateTime(2020, 05, 22)
              });
        }*/
    }
}
