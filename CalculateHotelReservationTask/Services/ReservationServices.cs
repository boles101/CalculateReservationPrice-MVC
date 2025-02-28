using CalculateHotelReservationTask.Data;
using CalculateHotelReservationTask.Models;
using System.Collections.Immutable;

namespace CalculateHotelReservationTask.Services
{
    public class ReservationServices : IReservationServices
    {
        private readonly HotelReservationDBcontext _context;
        private readonly IReservationRepository _reservationRepository;

        public ReservationServices(HotelReservationDBcontext context , IReservationRepository reservationRepository)
        {
            _context = context;
            _reservationRepository = reservationRepository;
        }

        public (decimal TotalPrice,int RoomCount) CalculateReservation(ReservationDto reservation)
        {

            int rooms= _reservationRepository.
                CalculateNumberOfRooms(reservation.NumberOfAdults ,reservation.NumberOfChildren);

            decimal totalPrice = 0;

            var roomRates = _reservationRepository
                .GetRoomRates(reservation.SelectedRoomTypeId, reservation.CheckInDate, reservation.CheckOutDate);


            var mealPlans = _reservationRepository
                .GetMealPlanRates(reservation.SelectedMealPlanId,reservation.CheckInDate,reservation.CheckOutDate);

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
                    Console.WriteLine("The room rate or the meal plan my have returned null (not found)");
                    return (0, 0);
                }
                decimal totalMealPricePerDay = (decimal)(mealPrice * (reservation.NumberOfAdults + reservation.NumberOfChildren));

                totalPrice += ratePrice + totalMealPricePerDay;
                totalMealPricePerDay = 0;
            }
            return (totalPrice,rooms);
        }

        
    }
}
