namespace Okane.Application;

public interface IExpenseService
{
    Expense RegisterExpense(Expense expense);
    IEnumerable<Expense> RetrieveAll();
    bool Delete(int id);
}