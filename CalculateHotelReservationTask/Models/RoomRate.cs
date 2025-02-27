using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculateHotelReservationTask.Models
{
    public class RoomRate
    {
        
        public int RoomRateId { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public DateOnly StartDate{ get; set; }
        public DateOnly EndDate { get; set; }
        [Required, Column(TypeName = "decimal(18, 2)")]
        public decimal  Price { get; set; }

    }
}
