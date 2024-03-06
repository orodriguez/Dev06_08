using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);

    void Delete(int id);

    IEnumerable<Expense> All();
}