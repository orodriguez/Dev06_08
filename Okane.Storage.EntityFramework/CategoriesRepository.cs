using System.Reflection.Metadata.Ecma335;
using Okane.Application;
using Okane.Domain;
using Okane.Storage.EntityFramework;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly OkaneDbContext _db;

    public CategoriesRepository(OkaneDbContext db) => _db = db;

    public Category Create(string categoryName)
    {
        Category newCategory = new Category
        {
            Name = categoryName
        };

        _db.Categories.Add(newCategory);
        _db.SaveChanges();
        var result = _db.Categories.First(category => category.Name == categoryName);

        return result;
    }

    public Category? ByName(string categoryName) => _db.Categories.FirstOrDefault(category => category.Name == categoryName);
    
    public Category? ById(int id) => _db.Categories.FirstOrDefault(category => category.Id == id);
    public IEnumerable<Category> Get() => _db.Categories.ToArray();

}