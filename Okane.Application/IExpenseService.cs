namespace Okane.Application;

public interface IExpenseService
{
    ExpenseResponse RegisterExpense(CreateExpenseRequest request);
    IEnumerable<ExpenseResponse> Search(string? category = null);
    bool Delete(int id);
}