using System.ComponentModel.DataAnnotations;

namespace CalculateHotelReservationTask.Models
{
    public class RoomType
    {
        [Required]
        public int RoomTypeId { get; set; }
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
    }
}
