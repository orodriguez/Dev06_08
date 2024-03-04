using Okane.Application;

namespace Okane.Tests;

public class ExpensesServiceTests
{
    [Fact]
    public void RegisterExpense()
    {
        var expensesRepository = new InMemoryExpensesRepository();
        var expenseService = new ExpenseService(expensesRepository);

        var expense = expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10
        });
        
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Groceries", expense.Category);
    }
}