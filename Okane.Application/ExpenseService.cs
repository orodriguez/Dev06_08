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
            CreatedAt = expense.CreatedAt
        };


    public ExpenseResponse updateExpense(int id, CreateExpenseRequest expenseRequest)
    {

        var tempExpense = this._expensesRepository.ById(id);

            tempExpense.Amount = expenseRequest.Amount;
            tempExpense.Category =expenseRequest.Category;
            tempExpense.Description = expenseRequest.Description;

        return new ExpenseResponse() 
        {
            Id = tempExpense.Id,
            Category = tempExpense.Category,
            Description = tempExpense.Description,
            Amount = tempExpense.Amount,
            CreatedAt = tempExpense.CreatedAt

        };
    
    }
}