using System.ComponentModel.DataAnnotations;

namespace Ganapati.Models
{
    public class LoginRequest
    {
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string UserName { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
