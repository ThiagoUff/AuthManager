using WebNotes.Auth.Domain.Entities.Request;
using WebNotes.Auth.Domain.Repository.User;

namespace WebNotes.Auth.Domain.Interfaces.Mapper
{
    public interface IUserMapper
    {
        User convert(CreateUserRequest request);
    }
}
