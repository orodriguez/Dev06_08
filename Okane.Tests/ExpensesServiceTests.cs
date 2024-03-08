using Okane.Application;
using Okane.Domain;

namespace Okane.Tests;

public class ExpensesServiceTests
{
    private readonly ExpenseService _expenseService;
    private readonly InMemoryExpensesRepository _expensesRepository;

    public ExpensesServiceTests()
    {
        _expensesRepository = new InMemoryExpensesRepository();
        _expenseService = new ExpenseService(_expensesRepository);
    }

    [Fact]
    public void RegisterExpense()
    {
        var response = _expenseService.RegisterExpense(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Description"
        });
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Groceries", response.Category);
        Assert.Equal("Description", response.Description);
    }

    [Fact]
    public void RetrieveAllExpenses()
    {
        _expenseService.RegisterExpense(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "My Description"
        });
        
        _expenseService.RegisterExpense(new CreateExpenseRequest
        {
            Category = "Entertainment",
            Amount = 20
        });

        var allExpenses = _expenseService.RetrieveAll()
            .ToArray();
        
        Assert.Equal(2, allExpenses.Length);

        var firstExpense = allExpenses.First();
        Assert.Equal(1, firstExpense.Id);
        Assert.Equal(10, firstExpense.Amount);
        Assert.Equal("Groceries", firstExpense.Category);
        Assert.Equal("My Description", firstExpense.Description);
    }

    [Fact]
    public void Delete()
    {
        _expenseService.RegisterExpense(new CreateExpenseRequest
        {
            Category = "Food",
            Amount = 15
        });

        _expenseService.RegisterExpense(new CreateExpenseRequest
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