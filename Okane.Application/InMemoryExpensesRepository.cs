using Okane.Domain;

namespace Okane.Application;

public class InMemoryExpensesRepository : IExpensesRepository
{
    private int _nextId = 1;
    private readonly IList<Expense> _expenses;
    private readonly IList<Category> _categories;

    public InMemoryExpensesRepository() : this(new List<Expense>(), new List<Category>())
    {
    }

    private InMemoryExpensesRepository(IList<Expense> expenses, IList<Category> categories) {

        _expenses = expenses;
        _categories = categories;
    }


    public void Add(Expense expense)
    {
        expense.Id = _nextId++;
        _expenses.Add(expense);
    }

    public IEnumerable<Expense> Search(string? categoryName = null) {
        var category = _categories.FirstOrDefault(c => c.Name == categoryName);
        var expenses = category == null ? _expenses : _expenses.Where( e => e.CategoryId == category?.Id);

        return expenses;
    }

    public void Delete(int id)
    {
        var expenseToDelete = _expenses
            .First(expense => expense.Id == id);
        _expenses.Remove(expenseToDelete);
    }

    public Expense? ById(int id) => 
        _expenses.FirstOrDefault(expense => expense.Id == id);

    public Expense Update(int id, UpdateExpenseRequest request)
    {

        var expense = _expenses.First(e => e.Id == id);

        Category category = new Category{
            Name = request.Category
        };

        expense.Category = category;
        expense.Amount = request.Amount;
        expense.Description = request.Description;

        return expense;
    }

    public int Count() => _expenses.Count;

    public void addCategory(Category category)
    {
       category.Id = _categories.Count + 1;
       _categories.Add(category);
    }

    public Category getCategoryById(int id)
    {
        
        return _categories.FirstOrDefault(c => c.Id == id)! ;
    }

    public Category GetCategoryByName(string categoryName)
    {
        var category = _categories.FirstOrDefault(c => c.Name == categoryName)!;
        return category;
    }
}