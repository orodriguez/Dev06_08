namespace Okane.Application;

public interface ICategoryService
{
    CategoryResponse Register(CreateCategoryRequest request);
    CategoryResponse? ById(int id);
    IEnumerable<CategoryResponse> Search(string? category = null);
    bool Delete(int id);
    CategoryResponse Update(int id, CreateCategoryRequest request);
}