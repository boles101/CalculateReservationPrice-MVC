using Microsoft.AspNetCore.Mvc.Rendering;

namespace CalculateHotelReservationTask.Models
{
    public interface IReservationRepository
    {
        IEnumerable<SelectListItem> RoomTypes();
        IEnumerable<SelectListItem> MealPlans();
        int CalculateNumberOfRooms(int numberOfAdults, int numberOfChildren);   
        IEnumerable<RoomRate> GetRoomRates(int selectedRoomTypeID, DateOnly checkin,DateOnly checkout);
        IEnumerable<MealPlanRate> GetMealPlanRates(int selectedMealPlanID, DateOnly checkin, DateOnly checkout);

    }
}
