using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using CarRental3._0.Repository;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICarRepository _carRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILocationService _locationService;
        private readonly IImageService _imageService;
        public CarController(ApplicationDbContext context, ICarRepository carRepository, UserManager<AppUser> userManager, ILocationService locationService, IImageService imageService)
        {
            _context = context;
            _carRepository = carRepository;
            _userManager = userManager;
            _locationService = locationService;
            _imageService = imageService;
        }
        public async Task<IActionResult> Index(string category, DateTime? startDate, DateTime? endDate,
    string sortBy, int? locationId, decimal? maxPrice)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedLocationId = locationId;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.SortBy = sortBy;
            ViewBag.MaxPrice = maxPrice;

            IEnumerable<Car> cars = await _carRepository.GetAll();

            // Apply date filter
            if (startDate.HasValue && endDate.HasValue)
            {
                cars = await _carRepository.GetAvailableCarsAsync(startDate.Value, endDate.Value);
            }

            // Apply category filter
            if (!string.IsNullOrEmpty(category))
            {
                cars = cars.Where(c => c.Category.ToString() == category);
            }

            // Apply location filter
            if (locationId.HasValue)
            {
                cars = cars.Where(c => c.LocationId == locationId);
            }

            // Apply price filter
            if (maxPrice.HasValue)
            {
                cars = cars.Where(c => c.DailyRate <= maxPrice);
            }

            // Apply sorting
            switch (sortBy)
            {
                case "price_asc":
                    cars = cars.OrderBy(c => c.DailyRate);
                    break;
                case "price_desc":
                    cars = cars.OrderByDescending(c => c.DailyRate);
                    break;
                case "year_asc":
                    cars = cars.OrderBy(c => c.Year);
                    break;
                case "year_desc":
                    cars = cars.OrderByDescending(c => c.Year);
                    break;
                default:
                    // Default sorting (by ID)
                    cars = cars.OrderBy(c => c.CarId);
                    break;
            }

            return View(cars);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            car.Location = await _context.Locations.FindAsync(car.LocationId);

            return View(car);
        }
        public IActionResult Create()
        {
            var model = new CarCreateViewModel
            {
                Locations = _context.Locations.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateViewModel createVM)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    Brand = createVM.Brand,
                    Model = createVM.Model,
                    Year = createVM.Year,
                    DailyRate = createVM.DailyRate,
                    Category = createVM.Category,
                    Status = createVM.Status,
                    LocationId = createVM.LocationId
                };

                if (createVM.ImageFile != null)
                {
                    car.ImagePath = await _imageService.SaveImageAsync(createVM.ImageFile);
                }

                _carRepository.Add(car);
                return RedirectToAction("Index");
            }

            // Repopulate locations if validation fails
            createVM.Locations = _context.Locations.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            });

            return View(createVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var locations = await _locationService.GetAllLocationsAsync();

            var viewModel = new EditCarViewModel
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                DailyRate = car.DailyRate,
                Category = car.Category,
                Status = car.Status,
                ExistingImagePath = car.ImagePath,
                LocationId = car.LocationId,
                Locations = locations.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                    Selected = l.Id == car.LocationId
                })
            };

            return View(viewModel);
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCarViewModel viewModel)
        {
            if (id != viewModel.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var car = await _carRepository.GetByIdAsync(id);
                if (car == null)
                {
                    return NotFound();
                }

                car.Brand = viewModel.Brand;
                car.Model = viewModel.Model;
                car.Year = viewModel.Year;
                car.DailyRate = viewModel.DailyRate;
                car.Category = viewModel.Category;
                car.Status = viewModel.Status;
                car.LocationId = viewModel.LocationId;

                if (viewModel.ImageFile != null && viewModel.ImageFile.Length > 0)
                {
                    // Delete old image if exists
                    if (!string.IsNullOrEmpty(car.ImagePath))
                    {
                        _imageService.DeleteImage(car.ImagePath);
                    }

                    car.ImagePath = await _imageService.SaveImageAsync(viewModel.ImageFile);
                }

                _carRepository.Update(car);
                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed, redisplay form
            var locations = await _locationService.GetAllLocationsAsync();
            viewModel.Locations = locations.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            });
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            // Load location information
            car.Location = await _context.Locations.FindAsync(car.LocationId);

            var viewModel = new DeleteCarViewModel
            {
                CarId = car.CarId,
                Brand = car.Brand,
                Model = car.Model,
                LocationName = car.Location?.Name ?? "Не е зададена",
                LocationId = car.LocationId
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            // Delete the image if it exists
            if (!string.IsNullOrEmpty(car.ImagePath))
            {
                _imageService.DeleteImage(car.ImagePath);
            }

            _carRepository.Delete(car);
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
                image = c.ImagePath,
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
