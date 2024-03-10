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
            CreateDate = DateTime.Now
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

    private static ExpenseResponse CreateExpenseResponse(Expense expense) =>
        new()
        {
            Id = expense.Id,
            Category = expense.Category,
            Description = expense.Description,
            Amount = expense.Amount,
            CreateDate = expense.CreateDate
        };

    public ExpenseResponse? UpdateExpense(int id, CreateExpenseRequest request)
    {
        var expense = _expensesRepository.ById(id);

        if (expense == null)
        {
            return null;
        }
        expense.Amount = request.Amount;
        expense.Category = request.Category;
        expense.Description = request.Description;

        _expensesRepository.Update(expense);

        return CreateExpenseResponse(expense);

    }
}