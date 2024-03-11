namespace Okane.Application;

public class UpdateExpenseRequest
{
    public required string Category { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
}