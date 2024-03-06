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

    public IEnumerable<Expense> All() => _expenses;
    
    public bool Delete(int id)
    {
        var expenseToDelete = _expenses
            .FirstOrDefault(expense => expense.Id == id);

        if (expenseToDelete == null)
            return false;
        
        _expenses.Remove(expenseToDelete);
        return true;
    }

    public int Count() => _expenses.Count;
}