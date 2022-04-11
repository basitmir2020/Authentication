﻿using Microsoft.AspNetCore.Identity;

namespace Authentication.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
