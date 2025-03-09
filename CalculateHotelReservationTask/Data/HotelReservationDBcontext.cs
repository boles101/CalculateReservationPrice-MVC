using CalculateHotelReservationTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;

namespace CalculateHotelReservationTask.Data
{
    public class HotelReservationDBcontext : DbContext
    {
        public HotelReservationDBcontext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region A different seeding method.
            //-------------------------------------------------------------------
            // make sure to add a new migration, comment the the SeedData.cs class
            //              and the method call in program.cs
            //-------------------------------------------------------------------



            //modelBuilder.Entity<RoomType>().HasData(

            // new RoomType { Description = "Standard Room" },
            // new RoomType { Description = "Sea View Room" },
            // new RoomType { Description = "Garden View Room" }
            //);

            //modelBuilder.Entity<RoomRate>().HasData(
            //    new RoomRate
            //    {
            //        RoomTypeId = 1,
            //        StartDate = new DateOnly(2025, 1, 1),
            //        EndDate = new DateOnly(2025, 1, 15),
            //        Price = 80,
            //    },

            //    new RoomRate
            //    {
            //        RoomTypeId = 1,
            //        StartDate = new DateOnly(2025, 1, 16),
            //        EndDate = new DateOnly(2025, 4, 30),
            //        Price = 50,
            //    },
            //    new RoomRate
            //    {
            //        RoomTypeId = 2,
            //        StartDate = new DateOnly(2025, 1, 1),
            //        EndDate = new DateOnly(2025, 1, 15),
            //        Price = 120,
            //    },
            //    new RoomRate
            //    {
            //        RoomTypeId = 2,
            //        StartDate = new DateOnly(2025, 1, 16),
            //        EndDate = new DateOnly(2025, 3, 31),
            //        Price = 90,
            //    },

            //    new RoomRate
            //    {
            //        RoomTypeId = 2,
            //        StartDate = new DateOnly(2025, 4, 1),
            //        EndDate = new DateOnly(2025, 4, 30),
            //        Price = 100,
            //    });


            //modelBuilder.Entity<MealPlan>().HasData(

            //    new MealPlan { PlanName = "Half Board" },
            //    new MealPlan { PlanName = "Full Board" },
            //    new MealPlan { PlanName = "All Inclusive" }
            //    );
            //modelBuilder.Entity<MealPlanRate>().HasData(
            //    new MealPlanRate
            //    {
            //        MealPlanId = 1,
            //        StartDate = new DateOnly(2025, 1, 1),
            //        EndDate = new DateOnly(2025, 5, 30),
            //        Price = 5
            //    },
            //    new MealPlanRate
            //    {
            //        MealPlanId = 1,
            //        StartDate = new DateOnly(2025, 6, 1),
            //        EndDate = new DateOnly(2025, 12, 31),
            //        Price = 10

            //    },
            //    new MealPlanRate
            //    {
            //        MealPlanId = 2,
            //        StartDate = new DateOnly(2025, 1, 1),
            //        EndDate = new DateOnly(2025, 5, 30),
            //        Price = 20

            //    },
            //    new MealPlanRate
            //    {
            //        MealPlanId = 2,
            //        StartDate = new DateOnly(2025, 6, 1),
            //        EndDate = new DateOnly(2025, 12, 31),
            //        Price = 25
            //    },
            //    new MealPlanRate
            //    {
            //        MealPlanId = 3,
            //        StartDate = new DateOnly(2025, 1, 1),
            //        EndDate = new DateOnly(2025, 5, 30),
            //        Price = 25
            //    },
            //    new MealPlanRate
            //    {
            //        MealPlanId = 3,
            //        StartDate = new DateOnly(2025, 6, 1),
            //        EndDate = new DateOnly(2025, 12, 31),
            //        Price = 30
            //    }); 

            #endregion


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoomRate>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MealPlanRate>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<RoomRate> roomRates { get; set; }
        public DbSet<RoomType> roomTypes { get; set; }
        public DbSet<MealPlan> mealPlans { get; set; }
        public DbSet<MealPlanRate>mealPlanRates { get; set; }

            
    }
}
