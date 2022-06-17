using WebNotes.Auth.Domain.Entities.Request;
using WebNotes.Auth.Domain.Entities.Response;

namespace WebNotes.Auth.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateUser(CreateUserRequest request);
        Task<LoginResponse> LoginUser(LoginRequest request);
    }
}
