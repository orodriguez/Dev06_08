using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expensesRepository;

    public ExpenseService(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public ExpenseResponse RegisterExpense(CreateExpenseRequest request)
    {
        var expense = new Expense
        {
            Amount = request.Amount,
            Description = request.Description,
            Category = request.Category,
            CreatedAt = DateTime.Now
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

    public ExpenseResponse UpdateExpense(int expenseId, UpdateExpenseRequest request)
    {
        var expense = new Expense
        {
            Amount = request.Amount,
            Description = request.Description,
            Category = request.Category,
            CreatedAt = DateTime.Now
        };
        
        _expensesRepository.Update(expenseId, expense);

        return CreateExpenseResponse(expense);
    }
    
    private static ExpenseResponse CreateExpenseResponse(Expense expense) =>
        new()
        {
            Id = expense.Id,
            Category = expense.Category,
            Description = expense.Description,
            Amount = expense.Amount,
            CreatedAt = expense.CreatedAt
        };
}