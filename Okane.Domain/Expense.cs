using System;

namespace Okane.Domain
{
    public class Expense
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string CategoryName => Category.Name;
        public string? Description { get; set; }
        public string? InvoiceUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } // Nueva propiedad para almacenar la fecha de actualización

        public int CategoryId { get; set; }
        public required Category Category { get; set; }
        public required User User { get; set; }
    }
}
