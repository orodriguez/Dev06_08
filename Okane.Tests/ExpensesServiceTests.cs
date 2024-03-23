using Okane.Application;
using Okane.Domain;

namespace Okane.Tests;

public class ExpensesServiceTests
{
    private readonly ExpenseService _expenseService;
    private readonly IExpensesRepository _expensesRepository;
    public ExpensesServiceTests()
    {
        _expensesRepository = new InMemoryExpensesRepository();
        _expenseService = new ExpenseService(_expensesRepository);
    }

    [Fact]
    public void RegisterExpense()
    {
        var expense = _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10,
            Description = "description"
        });
        
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Groceries", expense.Category);
        Assert.Equal("description", expense.Description);
    }

    [Fact]
    public void RetrieveAllExpenses()
    {
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceries",
            Amount = 10,
            Description = "description"
        });
        
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Entertainment",
            Amount = 20,
            Description = "Description_2"
        });

        var allExpenses = _expenseService.RetrieveAll()
            .ToArray();
        
        Assert.Equal(2, allExpenses.Length);

        var firstExpense = allExpenses.First();
        Assert.Equal(10, firstExpense.Amount);
    }

    [Fact]
    public void Delete(){

        _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceriess",
            Amount = 10,
            Description = "description"
        });
        _expenseService.RegisterExpense(new Expense
        {
            Category = "Groceriess",
            Amount = 112,
            Description = "description"
        });

        Assert.True(_expenseService.Delete(1));

        Assert.Equal(1, _expensesRepository.Count());
    }
}
