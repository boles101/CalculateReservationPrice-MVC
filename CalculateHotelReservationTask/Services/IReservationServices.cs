using CalculateHotelReservationTask.Models;

namespace CalculateHotelReservationTask.Services
{
    public interface IReservationServices
    {
        public (decimal TotalPrice, int RoomCount) CalculateReservation(ReservationDto reservation);
    }
}
