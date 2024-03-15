using System.Data.Common;

namespace Okane.Application;

public interface ICategoryService
{
    CategoryResponse Register(CreateCategoryRequest request);
    CategoryResponse? ById(int id);
    IEnumerable<CategoryResponse> Get();
}