using System.Diagnostics.CodeAnalysis;
using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly Func<DateTime> _getCurrentTime;
    private readonly ICategoriesRepository _categoriesRepository;

    public ExpenseService(
        IExpensesRepository expensesRepository, 
        ICategoriesRepository categoriesRepository,
        Func<DateTime> getCurrentTime)
    {
        _expensesRepository = expensesRepository;
        _categoriesRepository = categoriesRepository;
        _getCurrentTime = getCurrentTime;
    }

    public ExpenseResponse Register(CreateExpenseRequest request)
    {
        var category = _categoriesRepository.ByName(request.CategoryName);
        var currentTime = _getCurrentTime();
        
        var expense = new Expense
        {
            Amount = request.Amount,
            Description = request.Description,
            Category = category,
            InvoiceUrl = request.InvoiceUrl,
            CreatedAt = currentTime,
            UpdatedAt = currentTime 
        };
        
        _expensesRepository.Add(expense);
        
        return CreateExpenseResponse(expense);
    }

    public ExpenseResponse Update(int id, UpdateExpenseRequest request)
    {
        var category = _categoriesRepository.ByName(request.CategoryName);
        var updatedExpense = _expensesRepository.Update(id, request, category);
        return CreateExpenseResponse(updatedExpense);
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
            Category = expense.CategoryName,
            Description = expense.Description,
            Amount = expense.Amount,
            InvoiceUrl = expense.InvoiceUrl,
            CreatedAt = expense.CreatedAt,
            UpdatedAt = expense.UpdatedAt
        };
}