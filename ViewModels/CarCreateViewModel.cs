using CarRental3._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.ViewModels
{
    public class CarCreateViewModel
    {
        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal DailyRate { get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        public string Status { get; set; } = "В наличност";

        [Required(ErrorMessage = "Моля изберете локация")]
        [Display(Name = "Локация")]
        public int? LocationId { get; set; }

        // ← No [Required] here, and ensure it's never null:
        public List<SelectListItem> Locations { get; set; } = new();

        // File upload:
        [Required]
        public IFormFile Image { get; set; }
    }

}
