using Moq;
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
        _now = DateTime.Parse("2024-01-01");
        
        var response = _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Groceries",
            Amount = 10,
            Description = "description"
        });

        var expenseResponse = _expenseService.ById(registerExpenseResponse.Id);
  
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Groceries", expense.Category);
        Assert.Equal("description", expense.Description);
    }

    [Fact]
    public void SearchExpenses()
    {
        _expenseService.Register(new CreateExpenseRequest
        {

            Category = "Groceries",
            Amount = 10,
            Description = "description"
        });
        
        _expenseService.Register(new CreateExpenseRequest
        {
            Category = "Entertainment",
            Amount = 20,
            Description = "Description_2"
        });

        var allExpenses = _expenseService.Search()
            .ToArray();
        
        Assert.Equal(2, allExpenses.Length);

        var firstExpense = allExpenses.First();
        Assert.Equal(1, firstExpense.Id);
        Assert.Equal(10, firstExpense.Amount);
        Assert.Equal("Groceries", firstExpense.CategoryName);
        Assert.Equal("My Description", firstExpense.Description);
    }
    
    [Fact]
    public void SearchExpensesByCategory()
    {
        _expenseService.Register(new CreateExpenseRequest
        {
            CategoryName = "Groceries",
            Amount = 10,
            Description = "My Description"
        });
        
        _expenseService.Register(new CreateExpenseRequest
        {
            CategoryName = "Entertainment",
            Amount = 20
        });

        var expenses = _expenseService
            .Search(category: "Groceries")
            .ToArray();
        
        var firstExpense = Assert.Single(expenses);
        Assert.Equal(1, firstExpense.Id);
        Assert.Equal(10, firstExpense.Amount);
        Assert.Equal("Groceries", firstExpense.CategoryName);
        Assert.Equal("My Description", firstExpense.Description);
    }

    [Fact]
    public void Delete()
    {
        _expenseService.Register(new CreateExpenseRequest
        {
            CategoryName = "Food",
            Amount = 15
        });

        _expenseService.Register(new CreateExpenseRequest
        {
            CategoryName = "Fun",
            Amount = 10
        });

        Assert.True(_expenseService.Delete(1));
        
        Assert.Equal(1, _expensesRepository.Count());
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
}
