using CarRental3._0.Data;
using CarRental3._0.Models;
using CarRental3._0.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental3._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _logger = logger;
        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                if (user.IsBlacklisted)
                {
                    _logger.LogWarning($"Потребител от Черният списък {user.Email} се опита да се впише");
                    TempData["Error"] = "Вашият акаунт е в Черният списък. Моля свържете се с поддръжка";
                    return View(loginVM);
                }

                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["Error"] = "Грешна информация.";
            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "Този имейл е вече използван.";
                return View(registerVM);
            }

            var newUser = new AppUser()
            {
                Email = registerVM.Email,
                UserName = registerVM.FullName,
                FullName = registerVM.FullName,
                Role = UserRoles.User,
                BlacklistReason = " "
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                Console.WriteLine($"Потребител {newUser.Email} се регистрира успешно.");
                await _signInManager.SignInAsync(newUser, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in newUserResponse.Errors)
                {
                    Console.WriteLine($"Грешка при регистрация: {error.Description}");
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registerVM);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Car");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Blacklisted()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null || !user.IsBlacklisted)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BlacklistUser(string userId, string reason)
        {
            if (userId == _userManager.GetUserId(User))
            {
                TempData["Error"] = "Не е възможно да добавите себе си в Черният списък.";
                return RedirectToAction("Dashboard");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsBlacklisted = true;
                user.BlacklistReason = reason;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    var isCurrentUser = user.Id == _userManager.GetUserId(User);
                    if (!isCurrentUser)
                    {
                        await _signInManager.SignOutAsync();
                    }

                    TempData["Success"] = $"Потребителят {user.Email} е добавен в Черният списък.";
                }
            }
            return RedirectToAction("Dashboard");
        }
    }
}
