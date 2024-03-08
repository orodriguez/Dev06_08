namespace Okane.Application;

public class CreateExpenseRequest
{
    public int Amount { get; set; }
    public required string Category { get; set; }
    public string? Description { get; set; }
}