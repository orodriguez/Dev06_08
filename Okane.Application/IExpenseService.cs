using Okane.Domain;

namespace Okane.Application;

public interface IExpenseService
{
    Expense RegisterExpense(Expense expense);
    Expense RemoveExpense(int id);
    IEnumerable<Expense> RetrieveAll();
}