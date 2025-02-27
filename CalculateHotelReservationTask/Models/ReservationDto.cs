namespace CalculateHotelReservationTask.Models
{
    public class ReservationDto
    {
        public int SelectedRoomTypeId { get; set; }
        public int SelectedMealPlanId { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public DateOnly CheckInDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly CheckOutDate { get; set; }
        




    }
}
