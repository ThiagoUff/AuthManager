using Microsoft.AspNetCore.Identity;
using WebNotes.Auth.Domain.Entities.Request;
using WebNotes.Auth.Domain.Interfaces.Services;

namespace WebNotes.Auth.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager) { _userManager = userManager; }

        public async Task<IdentityResult> CreateUser(CreateUserRequest request)
        {
            IdentityUser userExists = await _userManager.FindByNameAsync(request.UserName);
            if (userExists is null)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = request.UserName,
                    AccessFailedCount = 0,
                    Email = request.UserName,
                    LockoutEnabled = false,
                    NormalizedEmail = request.UserName,
                    NormalizedUserName = request.UserName,
                    TwoFactorEnabled = false
                };
                return await _userManager.CreateAsync(user, request.Password);
            }
            throw new ("User já existe");
        }
    }
}
