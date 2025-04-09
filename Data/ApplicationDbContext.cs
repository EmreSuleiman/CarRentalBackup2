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

            modelBuilder.Entity<Car>().Property(c => c.DailyRate).HasPrecision(18, 2);
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                CarId = 1,
                Brand = "Toyota",
                Model = "Camry",
                Year = 2024,
                DailyRate = 30,
                Category = CarCategory.Икономична, // Use enum value
                ImagePath = "https://global.toyota/pages/models/images/camry/camry_010_s.jpg",
                LocationId = 0,
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
                Category = CarCategory.Икономична, // Use enum value
                Status = "В наличност",
                    LocationId = 2,
                    ImagePath = "https://di-uploads-pod3.dealerinspire.com/riversidetoyota/uploads/2018/12/2019-Toyota-Corolla-L-123118-copy.png"
                },
                new Car
                {
                    CarId = 3,
                    Brand = "Ford",
                    Model = "Transit",
                    Year = 2022,
                    DailyRate = 60,
                    Category = CarCategory.Ван,
                    LocationId = 0,
                    Status = "В наличност",
                    ImagePath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQle7rOjsAdhTfpggSwLzKnflAShadVzCWb7Q&s"
                },
                new Car
                {
                    CarId = 4,
                    Brand = "BMW",
                    Model = "X5",
                    Year = 2023,
                    DailyRate = 120,
                    Category = CarCategory.Луксозна,
                    Status = "В наличност",
                    LocationId = 0,
                    ImagePath = "https://prod.cosy.bmw.cloud/bmwweb/cosySec?COSY-EU-100-7331rjFhnOqIbqcTZ%25L3hpvYLfCny2oWYgpnQ97lX80UrOohZkVAfS5cVLNHCLvhJP%25z6eEzFu4fXBjvWzmQltE6BmudhSId4k9VTCrmpIUrOrJrhDGwXHi4T4qF9%25rJHFlFe6ou4TJIsIUzL3FlTv0VliyXIslGAzWECrv0s9OaRBE4GA0ogRwlNF9OALUxnXkIogOybW5KnvLUgChe2B5GybUEqjpx89ChbNmQtiPoEqhk7ZnHMLNmqn1cmaDyk7m5VKGPYCn178zB3vtE5V1Pa28mfN8zVMRpoMSkPazDxTKAdnMRaYWlALQ5DxRtesOwZ8YWxfj0gKcPteWS6AdaKMfjedwOQNBDS6jQ%25gZp2Ydw6ZuUNfptQ%25wc3bnFifZu%25KXh5JHSc3uBrq9YJdKX324mIKTQBrXpF7CAlZ24riI15ascpF4HvVAA0KiIFJGz7xABHvIT9a1nO2JGvloILUgpT9GsLvS6Uilo90yG10bHsLoAC9VshJ0yLOEozxqTACygNLpfmlOECUkaKH7sgNEbnR2V10UkNh5xWqVAbnkq8WeszOh5nmPej4agq857MjK0RUmP81D6psxb7MPVYws5Wh1DMzt%25r0eqVYDafu46jmztYRSaLP67aftxdRyww1RSfWQxDD%25VxdSeZWCuuzWQdjceTE3aeZQ6KjPpXRjcZwBZvHrx6Kc%252cqJ4WwBKupK5jFe%252B3iBucIjup2XH2fwv63iprJp9eGwXHi4TfF99%25UHNMClix2t5JUABNItPb9FSrTLn9lVc%25s6l89RpC0vQFju1dWS2aOIXRTVcwL9cvtT7672yzH3OYgMTN6uQmlDTI0Ccy2of4Y"
                },
                new Car
                {
                    CarId = 5,
                    Brand = "Volkswagen",
                    Model = "Transporter",
                    Year = 2013,
                    DailyRate = 110,
                    Category = CarCategory.Ван,
                    LocationId = 2,
                    Status = "В наличност",
                    ImagePath = "https://autochill.ru/wp-content/uploads/2021/03/kisspng-van-volkswagen-polo-car-volkswagen-transporter-5b0392784fe112.8189206915269607603272-removebg-preview.png"
                },
                new Car
                {
                    CarId = 6,
                    Brand = "Audi",
                    Model = "A4",
                    Year = 2022,
                    DailyRate = 90,
                    Category = CarCategory.Луксозна,
                    Status = "В наличност",
                    LocationId = 1,
                    ImagePath = "https://platform.cstatic-images.com/in/v2/stock_photos/c4359896-c20e-46da-87a2-a7b2734561b3/c0535e58-31b9-488d-b5b7-55818402e3e6.png"
                },
                new Car
                {
                    CarId = 7,
                    Brand = "Audi",
                    Model = "A6",
                    Year = 2023,
                    DailyRate = 130,
                    Category = CarCategory.Луксозна, // Use enum value
                    Status = "В наличност",
                    LocationId = 1,
                    ImagePath = "https://d2ivfcfbdvj3sm.cloudfront.net/7fc965ab77efe6e0fa62e4ca1ea7673bb25e46590c1e3d8e88cb10/stills_0640_png/MY2021/14787/14787_st0640_116.png"
                }
            );
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "София", Address = "бул. Цариградско шосе 115" },
                new Location { Id = 2, Name = "Пловдив", Address = "ул. Тракия 56" },
                new Location { Id = 3, Name = "Варна", Address = "ул. Приморска 28" },
                new Location { Id = 4, Name = "Бургас", Address = "ул. Александровска 45" },
                new Location { Id = 5, Name = "Русе", Address = "ул. Борисова 12" }
            );
        }
    }
}
