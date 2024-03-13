using Okane.Application;
using Okane.Domain;

namespace Okane.Tests;

public class ExpensesServiceTests
{
    private readonly ExpenseService _expenseService;
    private readonly InMemoryExpensesRepository _expensesRepository;
    private DateTime _now;

    public ExpensesServiceTests()
    {
        DateTime CurrentTime() => _now;
        _expensesRepository = new InMemoryExpensesRepository(CurrentTime);
        _expenseService = new ExpenseService(_expensesRepository, getCurrentTime: CurrentTime);
        _now = DateTime.Now;
    }

    [Fact]
    public void RegisterExpense()
    {
        _now = DateTime.Parse("2024-01-01");
        
        var response = _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Description",
            InvoiceUrl = "http://invoices.com/1"
        });
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Groceries", response.Category);
        Assert.Equal("Description", response.Description);
        Assert.Equal("http://invoices.com/1", response.InvoiceUrl);
        Assert.Equal(DateTime.Parse("2024-01-01"), response.CreatedAt);
        Assert.Equal(DateTime.Parse("2024-01-01"), response.UpdatedAt);
    }
    
    [Fact]
    public void UpdateExpense()
    {
        _now = DateTime.Parse("2024-02-02");
        
        var createResponse = _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Description"
        });
        
        _now = DateTime.Parse("2024-02-03");
        
        var updateResponse = _expenseService.Update(createResponse.Id, new UpdateExpenseRequest
        {
            Category = "Food",
            Amount = 15,
            Description = "New Description"
        });
        
        Assert.Equal(1, updateResponse.Id);
        Assert.Equal(15, updateResponse.Amount);
        Assert.Equal("Food", updateResponse.Category);
        Assert.Equal("New Description", updateResponse.Description);
        Assert.Equal(createResponse.CreatedAt, updateResponse.CreatedAt);
        Assert.Equal(DateTime.Parse("2024-02-03"), updateResponse.UpdatedAt);
    }
    
    [Fact]
    public void ById()
    {
        var registerExpenseResponse = _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Description"
        });

        var expenseResponse = _expenseService.ById(registerExpenseResponse.Id);
        
        Assert.Equal(1, registerExpenseResponse.Id);
        Assert.Equal(10, registerExpenseResponse.Amount);
        Assert.Equal("Groceries", registerExpenseResponse.Category);
        Assert.Equal("Description", registerExpenseResponse.Description);
    }
    
    [Fact]
    public void ById_NotFound()
    {
        var expenseResponse = _expenseService.ById(1);
        Assert.Null(expenseResponse);
    }

    [Fact]
    public void SearchExpenses()
    {
        _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "My Description"
        });
        
        _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Entertainment",
            Amount = 20
        });

        var allExpenses = _expenseService.Search()
            .ToArray();
        
        Assert.Equal(2, allExpenses.Length);

        var firstExpense = allExpenses.First();
        Assert.Equal(1, firstExpense.Id);
        Assert.Equal(10, firstExpense.Amount);
        Assert.Equal("Groceries", firstExpense.Category);
        Assert.Equal("My Description", firstExpense.Description);
    }
    
    [Fact]
    public void SearchExpensesByCategory()
    {
        _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "My Description"
        });
        
        _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Entertainment",
            Amount = 20
        });

        var expenses = _expenseService
            .Search(category: "Groceries")
            .ToArray();
        
        var firstExpense = Assert.Single(expenses);
        Assert.Equal(1, firstExpense.Id);
        Assert.Equal(10, firstExpense.Amount);
        Assert.Equal("Groceries", firstExpense.Category);
        Assert.Equal("My Description", firstExpense.Description);
    }

    [Fact]
    public void Delete()
    {
        _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Food",
            Amount = 15
        });

        _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Fun",
            Amount = 10
        });

        Assert.True(_expenseService.Delete(1));
        
        Assert.Equal(1, _expensesRepository.Count());
    }
    
    [Fact]
    public void Delete_NotFound() => 
        Assert.False(_expenseService.Delete(1));
}