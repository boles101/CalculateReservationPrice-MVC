using CalculateHotelReservationTask.Models;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace CalculateHotelReservationTask.ViewModel
{
    public class ReservationViewModel
    {
        public IEnumerable<SelectListItem> RoomTypes { get; set; }
        public IEnumerable<SelectListItem> MealPlans { get; set; }
        public ReservationDto ReservationData { get; set; }
    }
}
