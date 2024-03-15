using Moq;
using Okane.Application;

namespace Okane.Tests;

public class AuthServiceTests
{
    private readonly IAuthService _authService;
    private readonly InMemoryUsersRepository _usersRepository;

    public AuthServiceTests()
    {
        var mockPasswordHasher = new Mock<IPasswordHasher>();
        
        mockPasswordHasher
            .Setup(hasher => hasher.Hash("1234"))
            .Returns("TestHash");

        _usersRepository = new InMemoryUsersRepository();
        _authService = new AuthService(mockPasswordHasher.Object, _usersRepository);
    }

    [Fact]
    public void SignUp()
    {
        var createdUser = _authService.SignUp(new SignUpRequest
        {
            Email = "user@mail.com",
            Password = "1234"
        });
        
        Assert.Equal(1, createdUser.Id);
        Assert.Equal("user@mail.com", createdUser.Email);

        var user = _usersRepository.ById(1);
        Assert.Equal("TestHash", user.HashedPassword);
    }
}