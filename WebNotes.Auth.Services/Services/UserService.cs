using WebNotes.Auth.Domain.Auth;
using WebNotes.Auth.Domain.Entities.Request;
using WebNotes.Auth.Domain.Entities.Response;
using WebNotes.Auth.Domain.Interfaces.Helper;
using WebNotes.Auth.Domain.Interfaces.Mapper;
using WebNotes.Auth.Domain.Interfaces.Repository;
using WebNotes.Auth.Domain.Interfaces.Services;
using WebNotes.Auth.Domain.Repository.User;

namespace WebNotes.Auth.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly IJwtUtils _jwtUtils;
        public UserService(IUserRepository userRepository,
                           IUserMapper userMapper,
                           IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
            _jwtUtils = jwtUtils;
        }

        public async Task CreateUser(CreateUserRequest request)
        {
            User user = await _userRepository.GetByEmailAsync(request.Email);
            if (user is not null)
                throw new Exception("Email já cadastrado");
            await _userRepository.CreateAsync(_userMapper.convert(request));
        }

        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            User? user = await _userRepository.GetByEmailAsync(request.Email);
            if (user is null)
                throw new Exception("usuário não existente");
            if(user.Password == request.PassWord)
            {
                AuthToken token = await _jwtUtils.GenerateJwtToken(user);
                return new LoginResponse()
                {
                    JwtToken = token.Token,
                    Expiration = token.Expires,
                };
            }
            throw new Exception("Senha invalida");
        }
    }
}
