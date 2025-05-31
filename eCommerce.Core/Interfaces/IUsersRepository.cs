using eCommerce.Core.Entity;

namespace eCommerce.Core.Interfaces;

public interface IUsersRepository
{
    Task<AppUser?> AddUserAsync(AppUser user);
    Task<AppUser?> GetUserByEmailAndPasswordAsync(string? email, string? password);
    Task<AppUser?> GetUserByUserIdAsync(Guid userId);
}