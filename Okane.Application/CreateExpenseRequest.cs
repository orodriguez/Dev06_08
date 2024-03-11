using System;
using System.ComponentModel.DataAnnotations;

namespace Okane.Application
{
    public class CreateExpenseRequest
    {
        [Required]
        [Range(1, 1_000_000, ErrorMessage = "Amount is out of range")]
        public int Amount { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "Category is too long")]
        public string Category { get; set; }

        [MaxLength(250, ErrorMessage = "Description is too long")]
        public string? Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; } // Nueva propiedad para la fecha
    }
}
