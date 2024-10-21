using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
    public class AuthenticationRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
