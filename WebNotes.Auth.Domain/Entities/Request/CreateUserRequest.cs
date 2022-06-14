
namespace WebNotes.Auth.Domain.Entities.Request
{
    public class CreateUserRequest
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }    
    }
}
