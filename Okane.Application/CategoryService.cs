using System.Diagnostics.CodeAnalysis;
using Okane.Domain;

namespace Okane.Application;

public class CategoryService : ICategoryService
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoryResponse Register(CreateCategoryRequest request) {
        var category = _categoriesRepository!.Create(request.CategoryName);

        return CreateCategoryResponse(category);
    }

    public IEnumerable<CategoryResponse> Get()
    {
        var categories = _categoriesRepository.Get();
        return categories!.Select(CreateCategoryResponse);
    }

    public CategoryResponse? ById(int id)
    {
        var category = _categoriesRepository.ById(id);

        if(category != null)
            return CreateCategoryResponse(category);

        return null;
    }

    public CategoryResponse CreateCategoryResponse(Category category)
    {
        return new() { 
            Id = category.Id,
            CategoryName = category.Name
        };
    }

}