namespace Okane.Application;

public interface IExpenseService
{
    ExpenseResponse RegisterExpense(CreateExpenseRequest request);
    ExpenseResponse? ById(int id);
    IEnumerable<ExpenseResponse> Search(string? category = null);
    ExpenseResponse UpdateExpense(int expenseId, UpdateExpenseRequest request);
    bool Delete(int id);
}