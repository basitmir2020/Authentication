using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name Is Required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Is Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required!")]
        public string Password { get; set; }
    }
}
