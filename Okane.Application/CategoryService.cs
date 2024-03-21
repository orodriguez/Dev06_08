using Okane.Domain;

namespace Okane.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly Func<DateTime> _getCurrentTime;

        public CategoryService(IExpensesRepository expensesRepository, Func<DateTime> getCurrentTime)
        {
            _expensesRepository = expensesRepository;
            _getCurrentTime = getCurrentTime;
        }
        public Category Add(CreateCategoryRequest request)
        {
            Category category = new Category  {
                Name = request.Name
            };
            _expensesRepository.addCategory(category);
            return category;
        }

        public Category GetByName(string name)
        {
            return _expensesRepository.GetCategoryByName(name);
        }

    }

}