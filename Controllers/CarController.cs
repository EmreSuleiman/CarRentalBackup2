﻿using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarRepository _carRepository;
        private readonly UserManager<AppUser> _userManager;
        public CarController(ApplicationDbContext context, ICarRepository carRepository, UserManager<AppUser> userManager)
        {
            _context = context;
            _carRepository = carRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string category, DateTime? startDate, DateTime? endDate, string sortBy, int maxPrice = 200)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.MaxPrice = maxPrice;
            ViewBag.SortBy = sortBy;

            IEnumerable<Car> cars = await _carRepository.GetAll();

            // Apply date range filter
            if (startDate.HasValue && endDate.HasValue)
            {
                cars = await _carRepository.GetAvailableCarsAsync(startDate.Value, endDate.Value);
            }

            // Apply category filter (now using Bulgarian values)
            if (!string.IsNullOrEmpty(category))
            {
                cars = cars.Where(c => c.Category.ToString() == category);
            }

            // Apply price filter
            cars = cars.Where(c => c.DailyRate <= maxPrice);

            // Apply sorting
            cars = sortBy switch
            {
                "price_asc" => cars.OrderBy(c => c.DailyRate),
                "price_desc" => cars.OrderByDescending(c => c.DailyRate),
                "year_asc" => cars.OrderBy(c => c.Year),
                "year_desc" => cars.OrderByDescending(c => c.Year),
                _ => cars.OrderBy(c => c.CarId) // Default sorting
            };

            return View(cars.ToList());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            _carRepository.Add(car);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var carVM = new EditCarViewModel
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                DailyRate = car.DailyRate,
                Category = car.Category,
                Status = car.Status,
                Image = car.Image
            };

            return View(carVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditCarViewModel carVM)
        {
            if (!ModelState.IsValid)
            {
                return View(carVM);
            }

            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            car.Brand = carVM.Brand;
            car.Model = carVM.Model;
            car.Year = carVM.Year;
            car.DailyRate = carVM.DailyRate;
            car.Category = carVM.Category;
            car.Status = carVM.Status;
            car.Image = carVM.Image;

            var result = _carRepository.Update(car);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to update the car.");
                return View(carVM);
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View();
            return View(carDetails);
        }
        [HttpPost, ActionName("DeleteCar")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var carDetails = await _carRepository.GetByIdAsync(id);
            if (carDetails == null) return View();
            _carRepository.Delete(carDetails);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> FilterCars(DateTime startDate, DateTime endDate)
        {
            var availableCars = await _carRepository.GetAvailableCarsAsync(startDate, endDate);
            return Json(availableCars.Select(c => new
            {
                carId = c.CarId,
                brand = c.Brand,
                model = c.Model,
                dailyRate = c.DailyRate,
                image = c.Image,
                status = c.Status,
                isAdmin = User.Identity.IsAuthenticated && User.IsInRole("admin")
            }));
        }
        [HttpPost]
        public async Task<IActionResult> Rent(int carId, DateTime rentalDate, DateTime returnDate)
        {
            if (rentalDate >= returnDate)
            {
                TempData["Error"] = "Invalid rental period. The return date must be after the rental date.";
                return RedirectToAction("Detail", new { id = carId });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var car = await _carRepository.GetByIdAsync(carId);
            if (car == null)
            {
                return NotFound();
            }

            var rentalDays = (returnDate - rentalDate).Days;
            var totalCost = car.DailyRate * rentalDays;

            var rental = new Rental
            {
                RentalDate = rentalDate,
                ReturnDate = returnDate,
                TotalCost = totalCost,
                AppUserId = user.Id,
                CarId = carId
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            car.Status = "Rented";
            _carRepository.Update(car);

            TempData["Success"] = "Car rented successfully!";
            return RedirectToAction("Index");
        }
    }
}
