namespace Okane.Application;

public interface IExpenseService
{
    ExpenseResponse RegisterExpense(CreateExpenseRequest request);
    ExpenseResponse? ById(int id);
    IEnumerable<ExpenseResponse> Search(string? category = null);
    bool Delete(int id);
    ExpenseResponse updateExpense(int id, CreateExpenseRequest expenseRequest);

}