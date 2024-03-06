using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expenses;

    public ExpenseService(IExpensesRepository expenses) => 
        _expenses = expenses;

    public Expense RegisterExpense(Expense expense)
    {
        _expenses.Add(expense);
        return expense;
    }

    public IEnumerable<Expense> RetrieveAll() => 
        _expenses.All();


    public bool DeleteExpense(int expenseId) 
    {
        var expenseToDelete = this._expenses.GetById(expenseId);

        //We must make sure we did recieve something (that it actually exist)
        if (expenseToDelete != null)
        {
            this._expenses.Remove(expenseToDelete);
            return true;
        }
        else 
        {
            return false;
        }
    
    }
}