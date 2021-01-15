using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required] //validation - username cannot be empty
        public string UserName { get; set; }

        [Required] //validation - password cannot be empty
        public string Password { get; set; }
    }
}