using Okane.Domain;

namespace Okane.Application;

public class ExpenseService : IExpenseService
{
    private readonly IExpensesRepository _expensesRepository;

    public ExpenseService(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public Expense RegisterExpense(Expense expense)
    {
        _expensesRepository.Add(expense);
        return expense;
    }

    public IEnumerable<Expense> RetrieveAll() => 
        _expensesRepository.All();

    public bool Delete(int id) => 
        _expensesRepository.Delete(id);
}