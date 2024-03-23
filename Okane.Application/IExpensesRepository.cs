using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    IEnumerable<Expense> All();
    void Delete(int id);
    Expense byId(int id);
    int Count();
}