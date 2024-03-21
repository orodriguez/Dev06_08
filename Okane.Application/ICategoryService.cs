using Okane.Domain;

namespace Okane.Application
{
    public interface ICategoryService
    {
        Category Add(CreateCategoryRequest request);
        Category GetByName(string name);
        
    }

}