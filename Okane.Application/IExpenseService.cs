namespace Okane.Application;

public interface IExpenseService
{
    ExpenseResponse RegisterExpense(CreateExpenseRequest request);
    IEnumerable<ExpenseResponse> RetrieveAll();
    bool Delete(int id);
}