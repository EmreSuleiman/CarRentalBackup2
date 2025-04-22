using System.ComponentModel.DataAnnotations;
namespace CarRental3._0.ViewModels
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Номерът на картата е задължителен")]
        [CreditCard(ErrorMessage = "Невалиден номер")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        public string CardholderName { get; set; }

        [Required(ErrorMessage = "Датата на изтичане на картата е задължителна")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Невалидна дата (ММ/ГГ)")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV е задължетелен")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Невалиден CVV")]
        public string Cvv { get; set; }
        public int CarId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public decimal DailyRate { get; set; }
        public int RentalDays => (ReturnDate - RentalDate).Days;
        public decimal TotalCost => DailyRate * RentalDays;
    }
}
