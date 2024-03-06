using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    IEnumerable<Expense> All();
    Expense GetById(int id);
    void Remove(Expense expense);
}