using CarRental3._0.Data;
using CarRental3._0.Interfaces;
using CarRental3._0.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Repository
{
    public class CarRepository : ICarRepository
    {

        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
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
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
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
            return await _context.Cars.FirstOrDefaultAsync(i => i.CarId == id);
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
            return await _context.Cars.ToListAsync(); // Fallback to all cars if parsing fails
        }
        async Task<List<Car>> ICarRepository.GetAvailableCarsAsync(DateTime startDate, DateTime endDate, int? locationId = null)
        {
            var query = _context.Cars
            .Where(c => !c.Rentals.Any(r =>
                (r.RentalDate <= endDate && r.ReturnDate >= startDate)
            ));

            if (locationId.HasValue)
            {
                query = query.Where(c => c.LocationId == locationId);
            }

            return await query.ToListAsync();
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
