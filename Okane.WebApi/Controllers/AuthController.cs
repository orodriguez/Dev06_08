using Microsoft.AspNetCore.Mvc;
using Okane.Application;

namespace Okane.WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => 
        _authService = authService;

    // POST /expenses
    [HttpPost("signup")]
    public UserResponse Post(SignUpRequest request) => 
        _authService.SignUp(request);
}