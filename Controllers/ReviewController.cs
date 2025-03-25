using CarRental3._0.Data;
using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental3._0.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ReviewController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }

                var review = new Review
                {
                    UserId = user.Id,
                    Comment = model.Comment,
                    Rating = model.Rating,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Благодарим ви за вашия отзив!" });
            }

            return BadRequest(ModelState);
        }

        public IActionResult GetTopReviews()
        {
            var topReviews = _context.Reviews
                .Include(r => r.User)
                .Where(r => r.Rating == 5)
                .OrderByDescending(r => r.CreatedAt)
                .Take(3)
                .ToList();

            return Json(topReviews);
        }
    }
}
