using System.ComponentModel.DataAnnotations;

namespace CarRental3._0.Models
{
    public enum CarCategory
    {
        [Display(Name = "Икономична")]
        Economy,
        [Display(Name = "Луксозна")]
        Luxury,
        [Display(Name = "Ван")]
        Van
    }
}