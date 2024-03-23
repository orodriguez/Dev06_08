using Okane.Domain;
using System.Security.Cryptography.X509Certificates;

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
    public void Delete(int id) { 
        var expenseRemove = _expenses.FirstOrDefault(Expense => Expense.Id == id);

        if (expenseRemove != null) { 
        
            _expenses.Remove(expenseRemove);    
        }
    }

    public Expense byId(int id) {
         return _expenses.FirstOrDefault(expense => expense.Id == id);
    }

    public IEnumerable<Expense> All() => _expenses;

    public int Count()
    {
        return _expenses.Count;
    }

}