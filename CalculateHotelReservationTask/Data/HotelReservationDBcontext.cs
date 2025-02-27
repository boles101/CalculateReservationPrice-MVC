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
