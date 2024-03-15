using Okane.Application;

namespace Okane.WebApi;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string plainPassword) => 
        BCrypt.Net.BCrypt.HashPassword(plainPassword);

    public bool Verify(string plainPassword, string hashedPassword)
    {
        throw new NotImplementedException();
    }
}