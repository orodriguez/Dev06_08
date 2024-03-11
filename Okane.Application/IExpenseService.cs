using Okane.Domain;

namespace Okane.Application;

public interface IExpenseService
{
    Expense RegisterExpense(Expense expense);
    Expense? DeleteOne(int Id);
    IEnumerable<Expense> RetrieveAll();

}