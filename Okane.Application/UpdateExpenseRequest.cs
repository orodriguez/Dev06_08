using System.ComponentModel.DataAnnotations;

namespace Okane.Application;

public class UpdateExpenseRequest
{
    [Required]
    [Range(1, 1_000_000, ErrorMessage = "Amount is out of range")]
    public int Amount { get; set; }
    
    [Required]
    [MaxLength(80, ErrorMessage = "Category is too long")]
    public required string Category { get; set; }
    
    [MaxLength(250, ErrorMessage = "Description is too long")]
    public string? Description { get; set; }

    [RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", ErrorMessage = "Not a valid website URL")]
    public string? InvoiceUrl { get; set; }
}