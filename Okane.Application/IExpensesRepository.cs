using Okane.Domain;

namespace Okane.Application;

public interface IExpensesRepository
{
    void Add(Expense expense);
    IEnumerable<Expense> Search(string? categoryName = null);
    void Delete(int id);
    Expense? ById(int id);
    Expense Update(int id, UpdateExpenseRequest expense);
    void addCategory(Category category);
    Category getCategoryById(int id);
    Category GetCategoryByName(string categoryName);
}