using Okane.Application;

namespace Okane.Tests;

public class CreateExpenseRequestValidationsTests
{
    private readonly DataAnnotationsValidator<CreateExpenseRequest> _validator;

    public CreateExpenseRequestValidationsTests() =>
        _validator = new DataAnnotationsValidator<CreateExpenseRequest>();

    [Fact]
    public void Valid()
    {
        var validationResults = _validator
                .Validate(new CreateExpenseRequest
                {
                    Amount = 10,
                    Category = "DefaultCategory",
                    InvoiceUrl = "https://www.google.com/"
                });

        Assert.Empty(validationResults);
    }

    [Fact]
    public void InvalidAmount()
    {
        var validationResults = _validator
            .Validate(new CreateExpenseRequest
            {
                Amount = 0,
                Category = "DefaultCategory",
                InvoiceUrl = "https://www.google.com/"
            });

        var (property, errors) = Assert.Single(validationResults);

        Assert.Equal("Amount", property);
        Assert.Equal("Amount is out of range", errors.First());
    }

    [Fact]
    public void CategoryTooLong()
    {
        var validationResults = _validator
            .Validate(new CreateExpenseRequest
            {
                Amount = 10,
                Category = string.Join("", Enumerable.Repeat("a", 100)),
                InvoiceUrl = "https://www.google.com/"
            });

        var (property, errors) = Assert.Single(validationResults);

        Assert.Equal("Category", property);
        Assert.Equal("Category is too long", errors.First());
    }

    [Fact]
    public void DescriptionTooLong()
    {
        var validationResults = _validator
            .Validate(new CreateExpenseRequest
            {
                Amount = 10,
                Category = "DefaultCategory",
                Description = string.Join("", Enumerable.Repeat("a", 500)),
                InvoiceUrl = "https://www.google.com/"
            });

        var (property, errors) = Assert.Single(validationResults);

        Assert.Equal("Description", property);
        Assert.Equal("Description is too long", errors.First());
    }

        [Fact]
    public void InvalidUrl()
    {
        var validationResults = _validator
            .Validate(new CreateExpenseRequest
            {
                Amount = 10,
                Category = "DefaultCategory",
                InvoiceUrl = "myBadUrl"
            });

        var (property, errors) = Assert.Single(validationResults);

        Assert.Equal("InvoiceUrl", property);
        Assert.Equal("Not a valid website URL", errors.First());
    }
}