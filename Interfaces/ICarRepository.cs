using CarRental3._0.Models;

namespace CarRental3._0.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAll();
        Task<IEnumerable<Car>> GetFeaturedCars(int count);
        Task<IEnumerable<Car>> GetCarByCategory(string category);
        Task<bool> IsCarAvailable(int carId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<Car>> GetAvailableCarsAsync(DateTime startDate, DateTime endDate, int? locationId = null);
        Task<Car> GetByIdAsync(int id);
        Task<Car> GetByIdAsyncNotracking(int id);

        bool Add(Car car);
        bool Update(Car car);
        bool Delete(Car car);
        bool Save();
    }
}
