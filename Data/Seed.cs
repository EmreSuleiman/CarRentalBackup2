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
                    throw new InvalidOperationException("ApplicationDbContext не не регистриран като service provider.");
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
                    Category = CarCategory.Economy,
                    LocationId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    PublicId = "Toyota-Camry_fbbsnr"
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
                    PublicId = "Toyota-Corolla_kqtmzl"

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
                    PublicId = ""
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
                    PublicId = "BMW-X5_cwv21v"
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
                    PublicId = "VW-Transporter_bzovd6"
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
                    PublicId = "Audi-A4_e1zasy"
                },
                new Car
                {
                    CarId = 7,
                    Brand = "Audi",
                    Model = "A6",
                    Year = 2023,
                    DailyRate = 130,
                    Category = CarCategory.Luxury,
                    Status = "В наличност",
                    LocationId = 2,
                    PublicId = "p1wiboqjwwxh8dxszkef"
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