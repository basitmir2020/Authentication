using System.ComponentModel.DataAnnotations;

namespace Authentication.Dtos
{
    public class LoginDtos
    {
        [Required(ErrorMessage = "Email Is Required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required!")]
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}
