using CarRental3._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.ViewModels
{
    public class EditCarViewModel
    {
        public int CarId { get; set; }

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

        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }

        public int? LocationId { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public string? ExistingImagePath { get; internal set; }
    }
}
