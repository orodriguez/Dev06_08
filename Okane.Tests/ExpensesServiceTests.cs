using Okane.Application;

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
            Amount = 10
        });
        
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Groceries", expense.Category);
    }

    [Fact]
    public void RetrieveAllExpenses()
    {
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10
        });
        
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Entertainment",
            Amount = 20
        });

        var allExpenses = _expenseService.RetrieveAll()
            .ToArray();
        
        Assert.Equal(2, allExpenses.Length);

        var firstExpense = allExpenses.First();
        Assert.Equal(10, firstExpense.Amount);
    }
}