using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using CarRental3._0.Repository;
using CarRental3._0.Services;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IPhotoService _imageService;
        private readonly ILogger<CarRepository> _logger;
        public CarController(ApplicationDbContext context, ICarRepository carRepository, UserManager<AppUser> userManager, ILocationService locationService, IPhotoService imageService, ILogger<CarRepository> logger)
        {
            _context = context;
            _carRepository = carRepository;
            _userManager = userManager;
            _locationService = locationService;
            _imageService = imageService;
            _logger = logger;
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


            if (startDate.HasValue && endDate.HasValue)
            {
                cars = await _carRepository.GetAvailableCarsAsync(startDate.Value, endDate.Value);
            }

 
            if (!string.IsNullOrEmpty(category))
            {
                cars = cars.Where(c => c.Category.ToString() == category);
            }

            if (locationId.HasValue)
            {
                cars = cars.Where(c => c.LocationId == locationId);
            }


            if (maxPrice.HasValue)
            {
                cars = cars.Where(c => c.DailyRate <= maxPrice);
            }


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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new CarCreateViewModel
            {
                // Populate the dropdown on GET
                Locations = (await _locationService.GetAllLocationsAsync())
                    .Select(l => new SelectListItem
                    {
                        Value = l.Id.ToString(),
                        Text = l.Name
                    })
                    .ToList()
            };
            return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CarCreateViewModel vm)
        {
            vm.Locations = await _locationService
                    .GetAllLocationsAsync()
                    .ContinueWith(t => t.Result.Select(l => new SelectListItem
                    {
                        Value = l.Id.ToString(),
                        Text = l.Name
                    }).ToList());

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Validation failed: " +
                    string.Join(" | ", ModelState
                        .Where(kv => kv.Value.Errors.Any())
                        .Select(kv => $"{kv.Key}=[{string.Join(",", kv.Value.Errors.Select(e => e.ErrorMessage))}]")));
                return View(vm);
            }

            try
            {
                var result = await _imageService.AddPhotoAsync(vm.Image);
                if (result.Error != null)
                {
                    ModelState.AddModelError(
                        "Image",
                        $"Грешка при качване на снимка: {result.Error.Message}"
                    );
                    return View(vm);
                }

                // 2) All good — create and save
                var car = new Car
                {
                    Brand = vm.Brand,
                    Model = vm.Model,
                    Year = vm.Year,
                    DailyRate = vm.DailyRate,
                    Image = result.Url.ToString(),
                    PublicId = result.PublicId,
                    Category = vm.Category,
                    Status = vm.Status,
                    LocationId = vm.LocationId.Value
                };

                _carRepository.Add(car);
                if (!_carRepository.Save())
                {
                    ModelState.AddModelError("", "Неуспешно записване в базата данни");
                    return View(vm);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the error
                _logger.LogError(ex, "Error creating car listing");

                ModelState.AddModelError("", "An error occurred while creating the car listing");
                vm.Locations = _context.Locations
                    .Select(l => new SelectListItem
                    {
                        Value = l.Id.ToString(),
                        Text = l.Name
                    })
                    .ToList();
                return View(vm);
            }
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
                ExistingImagePath = car.Image,
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
                    if (!string.IsNullOrEmpty(car.Image))
                    {
                        await _imageService.DeletePhotoAsync(car.Image);
                    }

                    var uploadResult = await _imageService.AddPhotoAsync(viewModel.ImageFile);
                    car.Image = uploadResult.Url.ToString();
                }

                _carRepository.Update(car);
                return RedirectToAction(nameof(Index));
            }

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

            if (!string.IsNullOrEmpty(car.Image))
            {
                _imageService.DeletePhotoAsync(car.Image);
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
                image = c.Image,
                status = c.Status,
                isAdmin = User.Identity.IsAuthenticated && User.IsInRole("admin")
            }));
        }

        // Luhn algorithm implementation
        private bool IsValidCreditCard(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length < 13)
                return false;

            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(cardNumber[i]))
                    return false;

                int digit = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit = (digit % 10) + 1;
                }

                sum += digit;
                alternate = !alternate;
            }

            return (sum % 10 == 0);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Payment(int carId, DateTime rentalDate, DateTime returnDate)
        {
            var car = await _carRepository.GetByIdAsync(carId);
            if (car == null)
            {
                return NotFound();
            }

            // Check availability
            bool isAvailable = await _carRepository.IsCarAvailable(carId, rentalDate, returnDate);
            if (!isAvailable)
            {
                TempData["Error"] = "This car is not available for the selected dates.";
                return RedirectToAction("Detail", new { id = carId });
            }

            var model = new PaymentViewModel
            {
                CarId = carId,
                RentalDate = rentalDate,
                ReturnDate = returnDate,
                CarBrand = car.Brand,
                CarModel = car.Model,
                DailyRate = car.DailyRate
            };

            return View(model);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Car/Rent")]
        public async Task<IActionResult> Rent(PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Log all validation errors
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToList();

                foreach (var error in errors)
                {
                    Console.WriteLine($"Key: {error.Key}, Errors: {string.Join(", ", error.Errors.Select(e => e.ErrorMessage))}");
                }

                var carForDisplay = await _carRepository.GetByIdAsync(model.CarId);
                if (carForDisplay != null)
                {
                    model.CarBrand = carForDisplay.Brand;
                    model.CarModel = carForDisplay.Model;
                    model.DailyRate = carForDisplay.DailyRate;
                }
                return View("Payment", model);
            }

            // Check car availability
            bool isAvailable = await _carRepository.IsCarAvailable(model.CarId, model.RentalDate, model.ReturnDate);
            if (!isAvailable)
            {
                TempData["Error"] = "This car is no longer available for the selected dates.";
                return RedirectToAction("Detail", new { id = model.CarId });
            }

            // Process rental
            var user = await _userManager.GetUserAsync(User);
            var carToRent = await _carRepository.GetByIdAsync(model.CarId);

            var rental = new Rental
            {
                RentalDate = model.RentalDate,
                ReturnDate = model.ReturnDate,
                TotalCost = model.TotalCost,
                AppUserId = user.Id,
                CarId = model.CarId,
                PaymentDetails = $"Card ending in {model.CardNumber.Substring(model.CardNumber.Length - 4)}"
            };

            _context.Rentals.Add(rental);
            carToRent.Status = "Rented";
            await _context.SaveChangesAsync();

            TempData["Success"] = "Колата е наета успешно! Плащането е проверено.";
            return RedirectToAction("Index", "Dashboard");
        }
        [HttpPost]
        public async Task<IActionResult> ReturnCar(int rentalId)
        {
            var rental = await _context.Rentals
                .Include(r => r.Car)
                .FirstOrDefaultAsync(r => r.RentalId == rentalId);

            if (rental == null)
            {
                return NotFound();
            }


            rental.Car.Status = "В наличност";
            _carRepository.Update(rental.Car);



            rental.ReturnDate = DateTime.Now;
            await _context.SaveChangesAsync();

            TempData["Success"] = "Колата е върната успешно!";
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
