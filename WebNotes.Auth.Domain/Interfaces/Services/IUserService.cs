using Microsoft.AspNetCore.Identity;
using WebNotes.Auth.Domain.Entities.Request;

namespace WebNotes.Auth.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUser(CreateUserRequest request);
    }
}
