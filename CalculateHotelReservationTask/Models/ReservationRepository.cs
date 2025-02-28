using CalculateHotelReservationTask.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalculateHotelReservationTask.Models
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelReservationDBcontext _context;

        public ReservationRepository(HotelReservationDBcontext context)
        {
            _context = context;
        }

        public int CalculateNumberOfRooms(int numberOfAdults, int numberOfChildren)
        {
            { 
                // hard coded which is not an optimal solution..yes 3aref! 
                const int MaxChildrenPerRoom = 2;
                const int MaxAdultsPerRoom = 2;
                const int MaxCapacityPerRoom = 4;

                int totalRoomsForAdults = (numberOfAdults + MaxAdultsPerRoom - 1) / MaxAdultsPerRoom;
                int totalRoomsForChildren = (numberOfChildren + MaxChildrenPerRoom - 1) / MaxChildrenPerRoom;
                int totalRooms = (numberOfAdults + numberOfChildren + MaxCapacityPerRoom - 1) / MaxCapacityPerRoom;

                return Math.Max(Math.Max(totalRoomsForAdults, totalRoomsForChildren), totalRooms);

            }
        }

        public IEnumerable<MealPlanRate> GetMealPlanRates(int selectedMealPlanID, DateOnly checkin, DateOnly checkout)
        {
            var mealPlanRates = _context.mealPlanRates 
                .Where(x =>x.MealPlanId == selectedMealPlanID &&
                           x.StartDate<=checkout &&
                           x.EndDate>=checkin)
                .ToList();
            return mealPlanRates;
        }
        public IEnumerable<RoomRate> GetRoomRates(int selectedRoomTypeID, DateOnly checkin, DateOnly checkout)
        {
           var roomRates =  _context.roomRates
            .Where(x => x.RoomTypeId == selectedRoomTypeID &&
                        x.StartDate <= checkout &&
                        x.EndDate >= checkin)
            .ToList();
            return roomRates;
        }


        // used to load the room types and meal plans in the 2  drop down lists. 
        public IEnumerable<SelectListItem> MealPlans()
        {
            return _context.mealPlans.Select(mp => new SelectListItem
            {
                Value = mp.MealPlanId.ToString(),
                Text = mp.PlanName
            }).ToList();
        }

        public IEnumerable<SelectListItem> RoomTypes()
        {
            return _context.roomTypes.Select(rt =>
            new SelectListItem
            {
                Value = rt.RoomTypeId.ToString(),
                Text = rt.Description
            }).ToList();
        }
    }
}
