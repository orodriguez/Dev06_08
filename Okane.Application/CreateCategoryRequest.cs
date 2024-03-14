using System.ComponentModel.DataAnnotations;

public class CreateCategoryRequest
{
    [Required]
    [MaxLength(80, ErrorMessage = "Category is too long")]
    public required string CategoryName { get; set; }
}