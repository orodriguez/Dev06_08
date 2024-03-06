using Okane.Domain;

namespace Okane.Application;

public interface IExpenseService
{
    Expense RegisterExpense(Expense expense);
    IEnumerable<Expense> RetrieveAll();
    /*Following method is added to be able to delete expenses*/
    bool DeleteExpense(int expenseId);

}