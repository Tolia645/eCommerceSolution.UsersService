using eCommerce.Core.DTO;

namespace eCommerce.Core.Interfaces;

public interface IUsersService
{
    Task<AuthenticationResponse?> Register(RegisterRequest request);
    Task<AuthenticationResponse?> Login(LoginRequest request);
}