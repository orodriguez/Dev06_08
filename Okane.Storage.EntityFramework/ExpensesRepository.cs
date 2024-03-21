using Microsoft.EntityFrameworkCore;
using Okane.Application;
using Okane.Domain;

namespace Okane.Storage.EntityFramework;

public class ExpensesRepository : IExpensesRepository
{
    private readonly OkaneDbContext _db;

    public ExpensesRepository(OkaneDbContext db)
    {
        _db = db;
    }

    public void Add(Expense expense)
    {
        _db.Expenses.Add(expense);
        _db.SaveChanges();
    }

    public IEnumerable<Expense> Search(string? categoryName = null)
    {
        var category = _db.Categories.FirstOrDefault(c => c.Name == categoryName);
        return category!.Expenses.ToArray();
        

    }
    public void Delete(int id)
    {
        var expenseToDelete = _db.Expenses
            .First(expense => expense.Id == id);

        _db.Expenses.Remove(expenseToDelete);
        _db.SaveChanges();
    }

    public Expense? ById(int id) => 
        _db.Expenses.FirstOrDefault(expense => expense.Id == id);


    public Expense Update(int id, UpdateExpenseRequest request)
    {
        try
        {
            var expense = _db.Expenses.First(e => e.Id == id);

            expense.Category.Name = request.Category;
            expense.Amount = request.Amount;
            expense.Description = request.Description;

            _db.SaveChanges();
            return expense;
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }

    }

    public void addCategory(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
    }

    public Category getCategoryById(int id)
    {
        return _db.Categories.FirstOrDefault(c => c.Id == id)!;
    }

    public Category GetCategoryByName(string categoryName)
    {
        var category = _db.Categories.FirstOrDefault(c => c.Name == categoryName)!;
        return category;
    }
}