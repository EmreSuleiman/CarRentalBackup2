using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.Models
{
    public class Car
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
        public CarCategory Category { get; set; } = CarCategory.Икономична;

        [Required]
        public string Status { get; set; } = "В наличност";

        public string? ImagePath { get; set; }  // Make nullable

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int? LocationId { get; set; }
        public Location? Location { get; set; }  // Make nullable

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();  // Initialize
    }
}
