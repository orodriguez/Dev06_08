using Okane.Application;
using Okane.Domain;

namespace Okane.Tests;

public class ExpensesServiceTests
{
    private readonly ExpenseService _expenseService;

    public ExpensesServiceTests()
    {
        var expensesRepository = new InMemoryExpensesRepository();
        _expenseService = new ExpenseService(expensesRepository);
    }

    [Fact]
    public void RegisterExpense()
    {
        var expense = _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Presidente Light 16Onz"
        });
        
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Groceries", expense.Category);
        Assert.Equal("Presidente Light 16Onz", expense.Description);
    }

    [Fact]
    public void RetrieveAllExpenses()
    {
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Alturo Fuente, churchill, maduro."
        });
        
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Entertainment",
            Amount = 20,
            Description = "Presidente Light 16Onz"
        });

        var allExpenses = _expenseService.RetrieveAll()
            .ToArray();
        
        Assert.Equal(2, allExpenses.Length);

        var firstExpense = allExpenses.First();
        Assert.Equal(10, firstExpense.Amount);
    }

    [Fact]
    public void DeleteExpense()
    {
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Alturo Fuente, churchill, maduro."
        });
        
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Entertainment",
            Amount = 20,
            Description = "Presidente Light 16Onz"
        });

        var expense = _expenseService.RemoveExpense(1);

        var allExpenses = _expenseService.RetrieveAll()
            .ToArray();
     
        Assert.Equal(1, allExpenses.Length);
        Assert.Equal("Alturo Fuente, churchill, maduro.", expense.Description);
    }
}