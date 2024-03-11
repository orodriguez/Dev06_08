using Okane.Domain;

namespace Okane.Tests;

public class CSharpBasicsTests
{
    [Fact]
    public void RequiredProperties()
    {
        var expense = new Expense
        {
            Category = "Food",
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        };
    }
}