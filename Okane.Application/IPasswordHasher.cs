namespace Okane.Application;

public interface IPasswordHasher
{
    string Hash(string plainPassword);
}