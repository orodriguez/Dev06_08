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


    public Expense DeleteExpense(int id)
    {
        var expenseToDelete = _expenses.All().FirstOrDefault(expense => expense.Id == id);

        if (expenseToDelete != null)
        {
            _expenses.Delete(id);
        }

        return expenseToDelete!;
    }
}