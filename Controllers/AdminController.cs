using CarRental3._0.Data;
using CarRental3._0.Models;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ApplicationDbContext context, UserManager<AppUser> userManager, ILogger<AdminController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Dashboard()
        {
            var rentals = await _context.Rentals
                .Include(r => r.Car)
                .Include(r => r.AppUser)
                .ToListAsync();

            var usersList = await _userManager.Users.ToListAsync();

            var users = new List<UserViewModel>();

            foreach (var user in usersList)
            {
                var roles = await _userManager.GetRolesAsync(user);
                users.Add(new UserViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = roles.FirstOrDefault(),
                    IsBlacklisted = user.IsBlacklisted
                });
            }

            var blacklistedUsers = users.Where(u => u.IsBlacklisted).ToList();

            var viewModel = new AdminDashboardViewModel
            {
                Rentals = rentals,
                Users = users,
                BlacklistedUsers = blacklistedUsers
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> BlacklistUser(string userId, string reason)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsBlacklisted = true;
                await _userManager.UpdateAsync(user);
            }
            _logger.LogInformation($"Потребителят {User.Identity.Name} вкара в ченият списък {user.Email}. Причина: {reason}");
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> UnblacklistUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsBlacklisted = false;
                await _userManager.UpdateAsync(user);
            }
            _logger.LogInformation($"Потребителят {User.Identity.Name} махна от Черният списък {user.Email}");
            return RedirectToAction("Dashboard");
        }
    }
}
