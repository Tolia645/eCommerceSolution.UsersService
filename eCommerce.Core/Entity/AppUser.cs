using eCommerce.Core.DTO;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Core.Entity;

public class AppUser : IdentityUser
{
    public Guid UserId { get; set; } 
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public GenderOptions Gender { get; set; }
}