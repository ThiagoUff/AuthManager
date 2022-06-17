using System.ComponentModel.DataAnnotations;

namespace WebNotes.Auth.Domain.Entities.Request
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string PassWord { get; set; } = null!;
    }
}
