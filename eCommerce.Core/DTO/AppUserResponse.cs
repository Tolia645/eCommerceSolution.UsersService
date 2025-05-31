namespace eCommerce.Core.DTO;

public class AppUserResponse
{
    public Guid UserId { get; set; } 
    public string? Email { get; set; }
    public string? PersonName { get; set; }
    public string? Gender { get; set; }
}