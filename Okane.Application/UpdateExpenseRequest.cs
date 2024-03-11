using System.ComponentModel.DataAnnotations;

namespace Okane.Application;

public class UpdateExpenseRequest : CreateExpenseRequest
{
    [Required]
    [Range(1, 1_000_000_000, ErrorMessage = "The Id is too long.")]
    public required int Id { get; set; }
   
}