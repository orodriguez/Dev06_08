using System.Diagnostics.CodeAnalysis;
using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expenses;
    public int _Count;

    public ExpenseService(IExpensesRepository expenses) { 
        _expenses = expenses;
        _Count = _expenses.All().Count(); 
    }
    public Expense RegisterExpense(Expense expense)
    {
        _expenses.Add(expense);
        _Count++;
        return expense;
    }

    public IEnumerable<Expense> RetrieveAll() =>  _expenses.All();

    public Expense byId(int id ) {
        return _expenses.byId(id);
    }
    public bool Delete(int id) {
        var ExpensesDelete = _expenses.byId(id);
        if (ExpensesDelete == null) 
        {
            return false;
        }
        _expenses.Delete(id);
        _Count--;
            return true;


}