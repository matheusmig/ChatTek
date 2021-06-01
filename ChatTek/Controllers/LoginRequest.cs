using System.ComponentModel.DataAnnotations;

namespace ChatTek.Controllers
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
