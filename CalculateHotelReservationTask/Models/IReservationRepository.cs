using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalculateHotelReservationTask.Models
{
    public interface IReservationRepository
    {
        IEnumerable<SelectListItem> GetRoomTypes();
        IEnumerable<SelectListItem> GetMealPlans();
    }
}
