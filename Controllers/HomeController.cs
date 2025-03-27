using System.Diagnostics;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using CarRental3._0.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarRental3._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;


        public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }
        public async Task<IActionResult> Index()
        {
            // Get 6 featured cars for the homepage carousel
            var featuredCars = await _carRepository.GetFeaturedCars(4);
            return View(featuredCars);
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
