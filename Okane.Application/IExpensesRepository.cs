using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    void Remove(int id);
    IEnumerable<Expense> All();
}