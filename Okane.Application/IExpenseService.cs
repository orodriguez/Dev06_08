using Okane.Domain;
namespace Okane.Application
{
    public interface IExpenseService
    {
        // Define los métodos que necesitas en tu servicio
        Expense RegisterExpense(Expense expense);
        IEnumerable<Expense> RetrieveAll();
        bool Delete(int expenseId);
    }
}
