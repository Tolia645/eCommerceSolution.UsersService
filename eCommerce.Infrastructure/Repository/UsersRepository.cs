using Dapper;
using eCommerce.Core.Interfaces;
using eCommerce.Core.Entity;
using eCommerce.Core.DTO;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repository;

public class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _context;
    public UsersRepository(DapperDbContext context)
    {
        _context = context;
    }
    
    public async Task<AppUser?> AddUserAsync(AppUser user)
    {
        user.UserId = Guid.NewGuid();
        
        // Sql query to insert user into db
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES (@UserId, @Email, @PersonName, @Gender, @Password);";

        var rowCountAffected = await _context.DbConnection.ExecuteAsync(query, user);

        if (rowCountAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<AppUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        var parameters = new { Email = email, Password = password };
        
        AppUser? user = await _context.DbConnection.QueryFirstOrDefaultAsync<AppUser>(query, parameters);
        
        return user;
    }
}