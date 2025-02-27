using CalculateHotelReservationTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CalculateHotelReservationTask.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            using var context = new HotelReservationDBcontext(
            services.GetRequiredService<DbContextOptions<HotelReservationDBcontext>>());

            if (context.roomTypes.Any())
                return;

            context.roomTypes.AddRange(
            new RoomType { Description = "Standard Room" },
            new RoomType { Description = "Sea View Room" },
            new RoomType { Description = "Garden View Room" }
            );
            context.SaveChanges();

            int standardRoomTypeId = context.roomTypes.
            FirstOrDefault(r => r.Description == "Standard Room")?.RoomTypeId ?? 0;
            int seaViewRoomTypeId = context.roomTypes.
            FirstOrDefault(r => r.Description == "Sea View Room")?.RoomTypeId ?? 0;
            int gardenViewTypeId = context.roomTypes.
            FirstOrDefault(r => r.Description == "Garden View Room")?.RoomTypeId ?? 0;




            context.roomRates.AddRange(
                new RoomRate
                {
                    RoomTypeId = standardRoomTypeId,
                    StartDate = new DateOnly(2025, 1, 1),
                    EndDate = new DateOnly(2025, 1, 15),
                    Price = 80,
                },

                new RoomRate
                {
                    RoomTypeId = standardRoomTypeId,
                    StartDate = new DateOnly(2025, 1, 16),
                    EndDate = new DateOnly(2025, 4, 30),
                    Price = 50,
                },
                new RoomRate
                {
                    RoomTypeId = seaViewRoomTypeId,
                    StartDate = new DateOnly(2025, 1, 1),
                    EndDate = new DateOnly(2025, 1, 15),
                    Price = 120,
                },
                new RoomRate
                {
                    RoomTypeId = seaViewRoomTypeId,
                    StartDate = new DateOnly(2025, 1, 16),
                    EndDate = new DateOnly(2025, 3, 31),
                    Price = 90,
                },

                new RoomRate
                {
                    RoomTypeId = seaViewRoomTypeId,
                    StartDate = new DateOnly(2025, 4, 1),
                    EndDate = new DateOnly(2025, 4, 30),
                    Price = 100,
                });


            context.mealPlans.AddRange(

                new MealPlan { PlanName = "Half Board" },
                new MealPlan { PlanName = "Full Board" },
                new MealPlan { PlanName = "All Inclusive" }
                );
            context.SaveChanges();

            int halfBoardId = context.mealPlans.
                FirstOrDefault(n => n.PlanName == "Half Board")?.MealPlanId ?? 0;
            int fullBoardId = context.mealPlans.
                FirstOrDefault(n => n.PlanName == "Full Board")?.MealPlanId ?? 0;
            int allInclusiveId = context.mealPlans.
                FirstOrDefault(n => n.PlanName == "All Inclusive")?.MealPlanId ?? 0;



            context.AddRange(
                new MealPlanRate
                {
                    MealPlanId = halfBoardId,
                    StartDate = new DateOnly(2025, 1, 1),
                    EndDate = new DateOnly(2025, 5, 30),
                    Price = 5
                },
                new MealPlanRate
                {
                    MealPlanId= halfBoardId,
                    StartDate = new DateOnly(2025, 6, 1),
                    EndDate = new DateOnly(2025, 12, 31),
                    Price = 10

                },
                new MealPlanRate
                {
                    MealPlanId = fullBoardId,
                    StartDate = new DateOnly(2025, 1, 1),
                    EndDate = new DateOnly(2025, 5, 30),
                    Price = 20

                },
                new MealPlanRate
                {
                    MealPlanId = fullBoardId,
                    StartDate = new DateOnly(2025, 6, 1),
                    EndDate = new DateOnly(2025, 12, 31),
                    Price = 25
                },
                new MealPlanRate
                {
                    MealPlanId = allInclusiveId,
                    StartDate = new DateOnly(2025, 1, 1),
                    EndDate = new DateOnly(2025, 5, 30),
                    Price = 25
                },
                new MealPlanRate
                {
                    MealPlanId = allInclusiveId,
                    StartDate = new DateOnly(2025, 6, 1),
                    EndDate = new DateOnly(2025, 12, 31),
                    Price = 30
                });

            context.SaveChanges();
        }
    }
}
