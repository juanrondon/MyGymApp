using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyGymApp.DataAccess.Models
{
    public class MyGymAppDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<WorkoutRecord> WorkoutRecords { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<Muscle> Muscles { get; set; }


        public MyGymAppDbContext(DbContextOptions<MyGymAppDbContext> options) : base(options) { }

        //Seed some initial data
        public void Seed()
        {
            string[] muscles = {
                "Full Body",
                "Neck",
                "Shoulders",
                "Chest",
                "Biceps",
                "Forearms",
                "Abs",
                "Quads",
                "Traps",
                "Triceps",
                "Lats",
                "Middle Back",
                "Lower Back",
                "Glutes",
                "Hamstring",
                "Calves"
            };
            if (Muscles != null && !Muscles.Any())
            {
                foreach (string muscle in muscles)
                {
                    Muscles.Add(new Muscle
                    {
                        Name = muscle
                    });
                }
                SaveChanges();
            }

            if (Users != null && !Users.Any())
            {
                Users.Add(new User
                {
                    FirstName = "Juan",
                    LastName = "Rondon",
                    Email = "Juanrondon@me.com",
                    MobileNumber = "0415677654",
                    Address = new Address
                    {
                        StreetNumber = "21-23",
                        StreetName = "Sydney Ave",
                        Suburb = "Sydney",
                        Postcode = 2000
                    }
                });
            }
            SaveChanges();
        }
    }
}