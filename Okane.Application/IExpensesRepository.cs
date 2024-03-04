namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    IEnumerable<Expense> All();
}