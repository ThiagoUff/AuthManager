using WebNotes.Auth.Domain.Repository.User;

namespace WebNotes.Auth.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task CreateAsync(User newBook);
        Task<List<User>> GetAsync();
        Task<User?> GetAsync(string id);
        Task<User?> GetByEmailAsync(string email);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, User updatedBook);
    }
}
