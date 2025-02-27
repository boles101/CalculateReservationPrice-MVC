using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalculateHotelReservationTask.Models
{
    public class MealPlan
    {
        public int MealPlanId { get; set; }
        public string PlanName { get; set; } = string.Empty;
       



    }
}
