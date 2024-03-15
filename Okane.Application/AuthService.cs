using Okane.Domain;

namespace Okane.Application;

public class AuthService : IAuthService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUsersRepository _usersRepository;

    public AuthService(IPasswordHasher passwordHasher, IUsersRepository usersRepository)
    {
        _passwordHasher = passwordHasher;
        _usersRepository = usersRepository;
    }

    public UserResponse SignUp(SignUpRequest request)
    {
        var hashedPassword = _passwordHasher.Hash(request.Password);
        
        var user = new User
        {
            Email = request.Email,
            HashedPassword = hashedPassword
        };

        _usersRepository.Add(user);

        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email
        };
    }
}