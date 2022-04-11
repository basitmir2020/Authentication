using Authentication.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.ViewModel
{
    public class HomeVM
    {
        public SignInManager<AppUser> signInManager;
        public UserManager<AppUser> userManager;
    }
}
