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

    public Expense? DeleteOne(int id)=>
         _expenses.Delete(id);
        
    
        
}
