using CalculateHotelReservationTask.Models;
using CalculateHotelReservationTask.Services;
using CalculateHotelReservationTask.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalculateHotelReservationTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationServices _reservation;

        public HomeController(IReservationRepository reservationRepository,
                              IReservationServices reservation)
        {
            _reservationRepository = reservationRepository;
            _reservation = reservation;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new ReservationViewModel
            {
                RoomTypes = _reservationRepository.RoomTypes(),
                MealPlans = _reservationRepository.MealPlans()
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult ReservationTotal(ReservationViewModel reservation)
        {
            
          var calculationResult = _reservation.CalculateReservation(reservation.ReservationData);
          if (calculationResult.TotalPrice == 0)
            {
                ViewBag.ErrorMessage = "Failed to calculate the total price, please recheck the input";
                return View("Error");
            }

            ViewBag.TotalPrice = calculationResult.TotalPrice; 
            ViewBag.RoomCounter = calculationResult.RoomCount;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
