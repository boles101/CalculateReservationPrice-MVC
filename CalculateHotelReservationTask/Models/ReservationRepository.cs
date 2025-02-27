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
        public IEnumerable<SelectListItem> GetMealPlans()
        {
            return _context.mealPlans.Select(mp => new SelectListItem
            {
                Value = mp.MealPlanId.ToString(),
                Text = mp.PlanName
            }).ToList();
        }

        public IEnumerable<SelectListItem> GetRoomTypes()
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
