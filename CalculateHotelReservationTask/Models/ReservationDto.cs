using System.ComponentModel.DataAnnotations;

namespace CalculateHotelReservationTask.Models
{
    public class ReservationDto
    {
        public int SelectedRoomTypeId { get; set; }
        public int SelectedMealPlanId { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [Range(1,99,ErrorMessage ="At least one adult must be included.")]
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public DateOnly CheckInDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly CheckOutDate { get; set; }
        




    }
}
