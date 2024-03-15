namespace Okane.Application;

public interface IAuthService
{
    UserResponse SignUp(SignUpRequest request);
}