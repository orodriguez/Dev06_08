using System.Linq.Expressions;
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
    public Expense? Get(int id)
    {
        for(int i = 0; i < _expenses.Count; i++){
            if(_expenses[i].Id == id)
                return _expenses[i];
        }

        return null;
    }


    public Expense? Remove(int id)
    {
        Expense expense;
        
        for(int i = 0; i < _expenses.Count; i++){
            if(_expenses[i].Id == id){
                expense = _expenses[i];
                _expenses.RemoveAt(i);
                _nextId--;
                return expense;
            }
        }

        return null;
    }

    public IEnumerable<Expense> All() => _expenses;
}