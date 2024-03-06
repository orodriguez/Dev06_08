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

    //Lets return an Expense by an id
    public Expense GetById(int id)
    {
        //Expense tempExpense;
        for (int index = 0; index < this._expenses.Count; index++)
        {
            var currentExpenseId = this._expenses[index].Id;
            if (currentExpenseId == id)
            {
                  return  this._expenses[index];
            }
        
        }

        return null;
    }

    //Removing an expense from the list
    public void Remove(Expense expense)
    {
        this._expenses.Remove(expense);
    }
}