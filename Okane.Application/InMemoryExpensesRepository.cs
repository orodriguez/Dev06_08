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

    public int Count() => _expenses.Count;

    public void Update(Expense expense)
    {
        var currentExpense = _expenses.FirstOrDefault(e => e.Id == expense.Id);
        currentExpense!.Amount = expense.Amount;
        currentExpense!.Category = expense.Category;
        currentExpense!.Description = expense.Description;
    }
}