using Okane.Domain;

namespace Okane.Application;

public interface IUsersRepository
{
    void Add(User user);
}