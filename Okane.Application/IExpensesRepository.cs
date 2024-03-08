using Okane.Domain;

namespace Okane.Application
{
    public interface IExpensesRepository
    {
        Expense AddExpense(Expense expense);
        IEnumerable<Expense> GetAllExpenses();
        bool DeleteExpense(int expenseId);
    }
}
