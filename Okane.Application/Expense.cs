namespace Okane.Application;

public class Expense
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public required string Category { get; set; }
}