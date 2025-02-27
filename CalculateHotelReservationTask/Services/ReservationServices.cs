using CalculateHotelReservationTask.Data;
using CalculateHotelReservationTask.Models;
using System.Collections.Immutable;

namespace CalculateHotelReservationTask.Services
{
    public class ReservationServices : IReservationServices
    {
        private readonly HotelReservationDBcontext _context;

        public ReservationServices(HotelReservationDBcontext context)
        {
            _context = context;
        }

        public (decimal TotalPrice,int RoomCount) CalculateReservation(ReservationDto reservation)
        {
           int CalculateNumberOfRoom()
            {
                const int MaxChildrenPerRoom = 2;
                const int MaxAdultsPerRoom = 2;
                const int MaxCapacityPerRoom = 4;

                int totalRoomsForAdults = (reservation.NumberOfAdults + MaxAdultsPerRoom -1 ) / MaxAdultsPerRoom;
                int totalRoomsForChildren = (reservation.NumberOfChildren + MaxChildrenPerRoom -1 ) / MaxChildrenPerRoom;
                int totalRooms = (reservation.NumberOfAdults + reservation.NumberOfChildren + MaxCapacityPerRoom - 1 )/ MaxCapacityPerRoom;

                return Math.Max(Math.Max(totalRoomsForAdults,totalRoomsForChildren),totalRooms);

            }

            decimal totalPrice = 0;

            var roomRates = _context.roomRates
                    .Where(x => x.RoomTypeId == reservation.SelectedRoomTypeId &&
                                x.StartDate <= reservation.CheckOutDate &&
                                x.EndDate >= reservation.CheckInDate)
                    .ToList();


            var mealPlans = _context.mealPlanRates
                    .Where(x => x.MealPlanId == reservation.SelectedMealPlanId &&
                    x.StartDate <= reservation.CheckOutDate &&
                    x.EndDate >= reservation.CheckInDate)
                    .ToList();

            if (!(roomRates.Any() && mealPlans.Any()))
                return (0,0);       // the database is not seeded or something went wrong.



            for (DateOnly date = reservation.CheckInDate; date < reservation.CheckOutDate; date = date.AddDays(1))
            {
                var ratePrice = roomRates
                     .FirstOrDefault(x => date >= x.StartDate && date <= x.EndDate)?.Price ?? 0;
                var mealPrice = mealPlans
                    .FirstOrDefault(x => date >= x.StartDate && date <= x.EndDate)?.Price ?? 0;
                if (ratePrice == 0 || mealPrice == 0)
                {
                    Console.WriteLine("The room rate or the meal plane returned null (not found)");
                    return (0, 0);
                }
                decimal totalMealPricePerDay = (decimal)(mealPrice * (reservation.NumberOfAdults + reservation.NumberOfChildren));

                totalPrice += ratePrice + totalMealPricePerDay;
                totalMealPricePerDay = 0;
            }
            return (totalPrice,CalculateNumberOfRoom());
        }

        
    }
}
