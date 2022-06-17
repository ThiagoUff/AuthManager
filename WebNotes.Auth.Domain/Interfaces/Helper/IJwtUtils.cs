using WebNotes.Auth.Domain.Auth;
using WebNotes.Auth.Domain.Repository.User;

namespace WebNotes.Auth.Domain.Interfaces.Helper
{
    public interface IJwtUtils
    {
        public Task<AuthToken> GenerateJwtToken(User user);
        public string? ValidateJwtToken(string token);
    }
}
