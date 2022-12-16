using System.ComponentModel.DataAnnotations;
using tdAPI.Configuration;

  public class RegistrationResponse : AuthResult
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
