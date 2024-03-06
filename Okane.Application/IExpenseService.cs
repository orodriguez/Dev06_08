using Okane.Domain;

namespace Okane.Application;

public interface IExpenseService
{
    Expense DeleteExpense(int id);
    Expense RegisterExpense(Expense expense);
    IEnumerable<Expense> RetrieveAll();
}