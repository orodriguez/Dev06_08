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
            Description = "Carrot."
        });
        
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Groceries", expense.Category);
        Assert.Equal("Carrot.", expense.Description);
    }

    [Fact]
    public void RetrieveAllExpenses()
    {
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10,
            Description = "Bread."
        });
        
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Entertainment",
            Amount = 20,
            Description = "Movie."

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
            Description = "Apple, carrot."
        });
        
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Entertainment",
            Amount = 20,
            Description = "Romo"
        });

        var removedExpense = _expenseService.DeleteExpense(1);

        var allExpenses = _expenseService.RetrieveAll()
            .ToArray();
     
        Assert.Single(allExpenses);
        Assert.Equal("Apple, carrot.", removedExpense.Description);
    }
}
