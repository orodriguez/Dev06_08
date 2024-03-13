using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly Func<DateTime> _getCurrentTime;

    public ExpenseService(IExpensesRepository expensesRepository, Func<DateTime> getCurrentTime)
    {
        _expensesRepository = expensesRepository;
        _getCurrentTime = getCurrentTime;
    }

    public ExpenseResponse Register(CreateExpenseRequest request)
    {
        var dateStorage = _getCurrentTime();
        var expense = new Expense
        {
            Amount = request.Amount,
            Description = request.Description,
            Category = request.Category,
            InvoiceUrl = request.InvoiceUrl,
            CreatedAt = dateStorage,
            UpdatedAt = dateStorage
        };
        
        _expensesRepository.Add(expense);
        
        return CreateExpenseResponse(expense);
    }

    public ExpenseResponse Update(int id, UpdateExpenseRequest request)
    {
        
        var requested = new Expense
        {
            Amount = request.Amount,
            Description = request.Description,
            Category = request.Category,
            InvoiceUrl = request.InvoiceUrl,
            UpdatedAt = _getCurrentTime()
        };

        var expense = _expensesRepository.Update(id, requested);
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

    private static ExpenseResponse CreateExpenseResponse(Expense expense) =>
        new()
        {
            Id = expense.Id,
            Category = expense.Category,
            Description = expense.Description,
            Amount = expense.Amount,
            InvoiceUrl = expense.InvoiceUrl,
            CreatedAt = expense.CreatedAt
        };
}