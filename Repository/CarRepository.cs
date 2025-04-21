using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Repository
{
    public class CarRepository : ICarRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly ILogger<CarRepository> _logger;
        public CarRepository(ApplicationDbContext context, ILogger<CarRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool Add(Car car)
        {
            _context.Add(car);
            return Save();
        }

        public bool Delete(Car car)
        {
            _context.Remove(car);
            return Save();
        
        }

        public bool Save()
        {
            try
            {
                var saved = _context.SaveChanges();
                if (saved > 0)
                {
                    _logger.LogInformation("Changes saved successfully");
                    return true;
                }

                _logger.LogWarning("No changes were saved to the database");
                return false;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database update error occurred");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while saving changes");
                return false;
            }
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars
                .Include(c => c.Location)
                .ToListAsync();
        }
        public async Task<IEnumerable<Car>> GetFeaturedCars(int count)
        {
            return await _context.Cars
                .Where(c => c.Status == "В наличност")
                .OrderByDescending(c => c.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars
                .Include(c => c.Location)
                .FirstOrDefaultAsync(c => c.CarId == id);
        }

        public async Task<Car> GetByIdAsyncNotracking(int id)
        {
            return await _context.Cars.AsNoTracking().FirstOrDefaultAsync(i => i.CarId == id);
        }

        public async Task<IEnumerable<Car>> GetCarByCategory(string category)
        {
            if (Enum.TryParse(category, out CarCategory carCategory))
            {
                return await _context.Cars
                    .Where(c => c.Category == carCategory)
                    .ToListAsync();
            }
            return await _context.Cars.ToListAsync();
        }
        public async Task<IEnumerable<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate, int? locationId = null)
        {
            var query = _context.Cars
                .Include(c => c.Location) 
                .Where(c => !c.Rentals.Any(r =>
                    (r.RentalDate <= endDate && r.ReturnDate >= startDate)
                ));

            if (locationId.HasValue)
            {
                query = query.Where(c => c.LocationId == locationId);
            }

            return await query.ToListAsync();
        }
        public async Task<bool> IsCarAvailable(int carId, DateTime startDate, DateTime endDate)
        {
            var conflictingRentals = await _context.Rentals
                .Where(r => r.CarId == carId)
                .ToListAsync();

            foreach (var rental in conflictingRentals)
            {
                // Check if the requested period overlaps with the rental period
                bool periodOverlap = rental.RentalDate <= endDate && rental.ReturnDate >= startDate;

                // Check if car hasn't been returned yet
                bool notReturned = !rental.ActualReturnDate.HasValue || rental.ActualReturnDate.Value > startDate;

                if (periodOverlap && notReturned)
                {
                    return false;
                }
            }

            return true;
        }


        public bool Update(Car car)
        {
            if (_context.Entry(car).State == EntityState.Detached)
            {
                _context.Cars.Attach(car);
            }
            _context.Entry(car).State = EntityState.Modified;
            return Save();
        }


    }
}
