using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    Expense? Delete(int id);
    IEnumerable<Expense> All();

}