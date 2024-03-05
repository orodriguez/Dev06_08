using System.Reflection.Metadata.Ecma335;
using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expenses;

    public ExpenseService(IExpensesRepository expenses) => 
        _expenses = expenses;

    public Expense? RegisterExpense(Expense expense)
    {
        _expenses.Add(expense);
        return expense;
    }

    public Expense? RemoveExpense(int id) {
        return _expenses.Remove(id);
    }

    public IEnumerable<Expense> RetrieveAll() => 
        _expenses.All();
}