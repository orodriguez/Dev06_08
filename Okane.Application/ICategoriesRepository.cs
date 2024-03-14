using Okane.Domain;

namespace Okane.Application;

public interface ICategoriesRepository
{
    Category Create(string categoryName);
    Category ByName(string categoryName);
}