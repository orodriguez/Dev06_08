using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    IEnumerable<Expense> Search(string? categoryName = null);
    void Delete(int id);
    void Update(int id, Expense expense);
    Expense? ById(int id);
}