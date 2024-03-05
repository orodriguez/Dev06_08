using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    Expense? Get(int id);
    Expense? Remove(int id);
    IEnumerable<Expense> All();
}