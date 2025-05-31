using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Interfaces;
using Microsoft.Extensions.Logging;
using eCommerce.Core.Entity;

namespace eCommerce.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepo;
    private readonly ILogger<UsersService> _logger;
    private readonly IMapper _mapper;
    public UsersService(IUsersRepository usersRepo, ILogger<UsersService> logger, IMapper mapper)
    {
        _usersRepo = usersRepo;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        //public record RegisterRequest(string? Email, string? Password, string? PersonName, GenderOptions Gender);
        AppUser? user  = _mapper.Map<AppUser>(request);
        
        AppUser? registeredUser = await _usersRepo.AddUserAsync(user);
        
        if (registeredUser == null) {
            return null;
        }  
        
        return _mapper.Map<AuthenticationResponse>(registeredUser) with {Success = true, Token = "Token"};
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        AppUser? user = await _usersRepo.GetUserByEmailAndPasswordAsync(request.Email, request.Password);
        
        if (user == null) {
            return null;
        }    
        
        return _mapper.Map<AuthenticationResponse>(user) with {Success = true, Token = "Token"};
    }

    public async Task<AppUserResponse?> GetUserByUserId(Guid userId)
    {
        AppUser? user = await _usersRepo.GetUserByUserIdAsync(userId);
        return _mapper.Map<AppUserResponse>(user);
    }
}