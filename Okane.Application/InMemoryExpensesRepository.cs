using Okane.Domain;

namespace Okane.Application;

public class InMemoryExpensesRepository : IExpensesRepository
{
    private int _nextId = 1;
    private readonly IList<Expense> _expenses;

    public InMemoryExpensesRepository() : this(new List<Expense>())
    {
    }

    private InMemoryExpensesRepository(IList<Expense> expenses) => 
        _expenses = expenses;


    public void Add(Expense expense)
    {
        expense.Id = _nextId++;
        _expenses.Add(expense);
    }

    public IEnumerable<Expense> Search(string? categoryName = null) => 
        categoryName != null 
            ? _expenses.Where(expense => expense.Category == categoryName) 
            : _expenses;

    public void Delete(int id)
    {
        var expenseToDelete = _expenses
            .First(expense => expense.Id == id);
        _expenses.Remove(expenseToDelete);
    }

    public Expense? ById(int id) => 
        _expenses.FirstOrDefault(expense => expense.Id == id);

    public Expense Update(int id, UpdateExpenseRequest request)
    {
        // TODO: Add test for not found
        var expense = _expenses.First(e => e.Id == id);

        expense.Category = request.Category;
        expense.Amount = request.Amount;
        expense.Description = request.Description;

        return expense;
    }

    public int Count() => _expenses.Count;
}