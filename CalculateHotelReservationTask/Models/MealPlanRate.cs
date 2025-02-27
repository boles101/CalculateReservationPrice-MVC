using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalculateHotelReservationTask.Models
{
    public class MealPlanRate
    {
        public int MealPlanRateId { get; set; }
        public int MealPlanId { get; set; }
        public MealPlan mealPlan { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        [Required, Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
