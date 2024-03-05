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

    public void Remove(int id)
    {
        _nextId--;
        _expenses.RemoveAt(id - 1);
    }

    public IEnumerable<Expense> All() => _expenses;
}