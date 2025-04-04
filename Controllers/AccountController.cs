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
                    _logger.LogWarning($"Blacklisted user {user.Email} attempted to login");
                    TempData["Error"] = "Your account has been blacklisted. Please contact support.";
                    return View(loginVM);
                }

                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["Error"] = "Invalid login attempt.";
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
                TempData["Error"] = "This email address is already in use.";
                return View(registerVM);
            }

            var newUser = new AppUser()
            {
                Email = registerVM.Email,
                UserName = registerVM.Email, // Ensure UserName is set
                FullName = registerVM.FullName,
                Role = UserRoles.User
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                // Log the successful registration
                Console.WriteLine($"User {newUser.Email} registered successfully.");

                // Sign in the user after registration
                await _signInManager.SignInAsync(newUser, isPersistent: false);

                // Redirect to a success page or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Log errors
                foreach (var error in newUserResponse.Errors)
                {
                    Console.WriteLine($"Error during registration: {error.Description}");
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
            // Prevent self-blacklisting
            if (userId == _userManager.GetUserId(User))
            {
                TempData["Error"] = "You cannot blacklist yourself.";
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
                    // Sign out the user if they're currently logged in
                    var isCurrentUser = user.Id == _userManager.GetUserId(User);
                    if (!isCurrentUser)
                    {
                        await _signInManager.SignOutAsync();
                    }

                    TempData["Success"] = $"User {user.Email} has been blacklisted.";
                }
            }
            return RedirectToAction("Dashboard");
        }
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel registerVM)
        //{
        //    if (!ModelState.IsValid) return View(registerVM);
        //    var user = await _userManager.FindByEmailAsync(registerVM.Email);
        //    if(user != null)
        //    {
        //        TempData["Error"] = "This email address in already in user";
        //        return View(registerVM);
        //    }
        //    var newUser = new AppUser()
        //    {
        //        Email = registerVM.Email,
        //        UserName = registerVM.Email
        //    };
        //    var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

        //    if (newUserResponse.Succeeded) await _userManager.AddToRoleAsync(newUser, UserRoles.User);

        //    return View("Views/Home/Index.cshtml");
        //}

    }
}
