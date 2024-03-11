using System.ComponentModel.DataAnnotations;
using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expensesRepository;

    public ExpenseService(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public ExpenseResponse UpdateExpense(UpdateExpenseRequest request)
    {
        var expense = new Expense {
            Id = request.Id,
            Amount = request.Amount, 
            Category = request.Category,
            Description = request.Category,
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") // added date time
        };
        
        if(_expensesRepository.Update(expense))
            return CreateExpenseResponse(expense);
        
        return CreateExpenseResponse(expense: null);
    }

    public ExpenseResponse RegisterExpense(CreateExpenseRequest request)
    {
        var expense = new Expense
        {
            Amount = request.Amount,
            Description = request.Description,
            Category = request.Category,
            Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") // added date time
        };
        
        _expensesRepository.Add(expense);
        
        return CreateExpenseResponse(expense);
    }

    public ExpenseResponse? ById(int id)
    {
        var expense = _expensesRepository.ById(id);

        return expense == null ? null : CreateExpenseResponse(expense);
    }

    public IEnumerable<ExpenseResponse> Search(string? category = null) => 
        _expensesRepository
            .Search(category)
            .Select(CreateExpenseResponse);

    public bool Delete(int id)
    {
        var expenseToDelete = _expensesRepository.ById(id);

        if (expenseToDelete == null)
            return false;
        
        _expensesRepository.Delete(id);
        return true;
    }

    private static ExpenseResponse CreateExpenseResponse(Expense? expense)
    {
        return new()
        {
            Id = expense.Id,
            Category = expense.Category,
            Description = expense.Description,
            Amount = expense.Amount,
            Timestamp = expense.Timestamp.ToString()
        };
    }
}