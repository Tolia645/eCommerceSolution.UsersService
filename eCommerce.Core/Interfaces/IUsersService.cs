using eCommerce.Core.DTO;
using eCommerce.Core.Entity;

namespace eCommerce.Core.Interfaces;

public interface IUsersService
{
    Task<AuthenticationResponse?> Register(RegisterRequest request);
    Task<AuthenticationResponse?> Login(LoginRequest request);
    Task<AppUserResponse> GetUserByUserId(Guid id);
}