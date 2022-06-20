using WebNotes.Auth.Domain.Entities.Request;
using WebNotes.Auth.Domain.Interfaces.Mapper;
using WebNotes.Auth.Domain.Repository.User;

namespace WebNotes.Auth.Services.Mapper
{
    public class UserMapper : IUserMapper
    {
        public User convert(CreateUserRequest request)
        {
            return new User()
            {
                Id = Convert.ToBase64String((Guid.NewGuid()).ToByteArray()),
                Email = request.Email,
                Username = request.UserName,
                Password = request.Password,
                LoginCount = 0,
            };
        }
    }
}
