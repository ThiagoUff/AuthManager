namespace WebNotes.Auth.Domain.Auth
{
    public class AuthToken
    {
        public string? Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
