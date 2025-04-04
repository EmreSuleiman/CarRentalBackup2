using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Data
{
    public static class Seed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        }
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (context == null)
                {
                    throw new InvalidOperationException("ApplicationDbContext is not registered in the service provider.");
                }

                await context.Database.MigrateAsync();

                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(new List<Car>()
                {
                    new Car
                {
                CarId = 1,
                Brand = "Toyota",
                Model = "Camry",
                Year = 2024,
                DailyRate = 30,
                Category = CarCategory.Икономична, // Use enum value
                Image = "https://global.toyota/pages/models/images/camry/camry_010_s.jpg",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
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
                Image = "https://di-uploads-pod3.dealerinspire.com/riversidetoyota/uploads/2018/12/2019-Toyota-Corolla-L-123118-copy.png"
                },
                new Car
                {
                    CarId = 3,
                    Brand = "Ford",
                    Model = "Transit",
                    Year = 2022,
                    DailyRate = 60,
                    Category = CarCategory.Ван,
                    Status = "В наличност",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQle7rOjsAdhTfpggSwLzKnflAShadVzCWb7Q&s"
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
                    Image = "https://prod.cosy.bmw.cloud/bmwweb/cosySec?COSY-EU-100-7331rjFhnOqIbqcTZ%25L3hpvYLfCny2oWYgpnQ97lX80UrOohZkVAfS5cVLNHCLvhJP%25z6eEzFu4fXBjvWzmQltE6BmudhSId4k9VTCrmpIUrOrJrhDGwXHi4T4qF9%25rJHFlFe6ou4TJIsIUzL3FlTv0VliyXIslGAzWECrv0s9OaRBE4GA0ogRwlNF9OALUxnXkIogOybW5KnvLUgChe2B5GybUEqjpx89ChbNmQtiPoEqhk7ZnHMLNmqn1cmaDyk7m5VKGPYCn178zB3vtE5V1Pa28mfN8zVMRpoMSkPazDxTKAdnMRaYWlALQ5DxRtesOwZ8YWxfj0gKcPteWS6AdaKMfjedwOQNBDS6jQ%25gZp2Ydw6ZuUNfptQ%25wc3bnFifZu%25KXh5JHSc3uBrq9YJdKX324mIKTQBrXpF7CAlZ24riI15ascpF4HvVAA0KiIFJGz7xABHvIT9a1nO2JGvloILUgpT9GsLvS6Uilo90yG10bHsLoAC9VshJ0yLOEozxqTACygNLpfmlOECUkaKH7sgNEbnR2V10UkNh5xWqVAbnkq8WeszOh5nmPej4agq857MjK0RUmP81D6psxb7MPVYws5Wh1DMzt%25r0eqVYDafu46jmztYRSaLP67aftxdRyww1RSfWQxDD%25VxdSeZWCuuzWQdjceTE3aeZQ6KjPpXRjcZwBZvHrx6Kc%252cqJ4WwBKupK5jFe%252B3iBucIjup2XH2fwv63iprJp9eGwXHi4TfF99%25UHNMClix2t5JUABNItPb9FSrTLn9lVc%25s6l89RpC0vQFju1dWS2aOIXRTVcwL9cvtT7672yzH3OYgMTN6uQmlDTI0Ccy2of4Y"
                },
                new Car
                {
                    CarId = 5,
                    Brand = "Volkswagen",
                    Model = "Transporter",
                    Year = 2013,
                    DailyRate = 110,
                    Category = CarCategory.Ван,
                    Status = "В наличност",
                    Image = "https://autochill.ru/wp-content/uploads/2021/03/kisspng-van-volkswagen-polo-car-volkswagen-transporter-5b0392784fe112.8189206915269607603272-removebg-preview.png"
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
                    Image = "https://platform.cstatic-images.com/in/v2/stock_photos/c4359896-c20e-46da-87a2-a7b2734561b3/c0535e58-31b9-488d-b5b7-55818402e3e6.png"
                }
                    });
                    context.SaveChangesAsync();
                }
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(new List<Location>()
                    {
                        new Location()
                        {
                            Id = 1,
                            Name = "София",
                            Address = "ул. Витоша 1",
                        },
                        new Location()
                        {
                            Id = 2,
                            Name = "Пловдив",
                            Address = "бул. Цар Борис III 2",
                        },
                        new Location()
                        {
                            Id = 3,
                            Name = "Варна",
                            Address = "бул. Княз Борис I 3",
                        },
                        new Location()
                        {
                            Id = 4,
                            Name = "Бургас",
                            Address = "ул. Александровска 4",
                        },
                        new Location()
                        {
                            Id = 5,
                            Name = "Русе",
                            Address = "ул. Александровска 5",
                        },
                    });
                    context.SaveChangesAsync();
                }
        }
        }

        public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                // Roles
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                // Users
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        FullName = "Admin",
                        BlacklistReason = " "
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        FullName = "App User",
                        BlacklistReason = " "
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}