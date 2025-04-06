using CarRental3._0.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.ViewModels
{
    public class DeleteCarViewModel
    {
        public int CarId { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        public string LocationName { get; set; }
        [Required]
        public int? LocationId { get; set; }
    }
}
