using Okane.Domain;

namespace Okane.Tests;

public class CSharpBasicsTests
{
    [Fact]
    public void RequiredProperties()
    {
        var category = new Category
        {
            Name = "Food"
        };
    }
}