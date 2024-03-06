using Okane.Domain;

namespace Okane.Tests;

public class CSharpBasicsTests
{
    [Fact]
    public void RequiredProperties()
    {
        var expense = new Expense
        {
            Category = "Food"
        };
    }
}