using CarRental3._0.Data;
using CarRental3._0.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocationsAsync();
    }
}
