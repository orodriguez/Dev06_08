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
        return categoryName != null
            ? _db.Expenses
                .Where(expense => expense.Category == categoryName)
            : _db.Expenses;
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

            expense.Category = request.Category;
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
}