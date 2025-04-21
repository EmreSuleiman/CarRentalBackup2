using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarRental3._0.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Review> Reviews { get; set;}
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "София", Address = "бул. Цариградско шосе 115" },
                new Location { Id = 2, Name = "Пловдив", Address = "ул. Тракия 56" },
                new Location { Id = 3, Name = "Варна", Address = "ул. Приморска 28" },
                new Location { Id = 4, Name = "Бургас", Address = "ул. Александровска 45" },
                new Location { Id = 5, Name = "Русе", Address = "ул. Борисова 12" }
            );
            modelBuilder.Entity<Car>().Property(c => c.DailyRate).HasPrecision(18, 2);
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarId = 1,
                    Brand = "Toyota",
                    Model = "Camry",
                    Year = 2024,
                    DailyRate = 30,
                    Category = CarCategory.Economy, // Use enum value
                    LocationId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new Car
                {
                    CarId = 2,
                    Brand = "Toyota",
                    Model = "Corolla",
                    Year = 2023,
                    DailyRate = 40,
                    Category = CarCategory.Economy, // Use enum value
                    Status = "В наличност",
                    LocationId = 3,
                    
                },
                new Car
                {
                    CarId = 3,
                    Brand = "Ford",
                    Model = "Transit",
                    Year = 2022,
                    DailyRate = 60,
                    Category = CarCategory.Van,
                    LocationId = 2,
                    Status = "В наличност",
                },
                new Car
                {
                    CarId = 4,
                    Brand = "BMW",
                    Model = "X5",
                    Year = 2023,
                    DailyRate = 120,
                    Category = CarCategory.Luxury,
                    Status = "В наличност",
                    LocationId = 1,
                },
                new Car
                {
                    CarId = 5,
                    Brand = "Volkswagen",
                    Model = "Transporter",
                    Year = 2013,
                    DailyRate = 110,
                    Category = CarCategory.Van,
                    LocationId = 3,
                    Status = "В наличност",
                },
                new Car
                {
                    CarId = 6,
                    Brand = "Audi",
                    Model = "A4",
                    Year = 2022,
                    DailyRate = 90,
                    Category = CarCategory.Luxury,
                    Status = "В наличност",
                    LocationId = 4,
                    
                },
                new Car
                {
                    CarId = 7,
                    Brand = "Audi",
                    Model = "A6",
                    Year = 2023,
                    DailyRate = 130,
                    Category = CarCategory.Luxury, // Use enum value
                    Status = "В наличност",
                    LocationId = 2,
                    
                }
            ); 
        }
    }
}
