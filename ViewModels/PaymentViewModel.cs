using System.ComponentModel.DataAnnotations;
namespace CarRental3._0.ViewModels
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Card number is required")]
        [CreditCard(ErrorMessage = "Invalid credit card number")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Cardholder name is required")]
        public string CardholderName { get; set; }

        [Required(ErrorMessage = "Expiration date is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Invalid expiration date (MM/YY)")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV is required")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Invalid CVV")]
        public string Cvv { get; set; }

        // Rental details
        public int CarId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        // Car details for display
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public decimal DailyRate { get; set; }

        // Calculated properties
        public int RentalDays => (ReturnDate - RentalDate).Days;
        public decimal TotalCost => DailyRate * RentalDays;
    }
}
