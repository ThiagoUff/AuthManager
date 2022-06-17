namespace WebNotes.Auth.Domain.Entities.Response
{
    public class LoginResponse
    {
        public string? JwtToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
