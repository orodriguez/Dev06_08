using System.Reflection.Metadata.Ecma335;
using Okane.Application;
using Okane.Domain;
using Okane.Storage.EntityFramework;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly OkaneDbContext _db;

    public CategoriesRepository(OkaneDbContext db) => _db = db;

    public Category ByName(string categoryName)
    {
        var result = _db.Categories.FirstOrDefault(category => category.Name == categoryName);

        if (result != null)
        {
            return result;
        }

        Category newCategory = new Category
        {
            Name = categoryName
        };

        _db.Categories.Add(newCategory);
        _db.SaveChanges();
        result = _db.Categories.First(category => category.Name == categoryName);

        return result;
    }
}