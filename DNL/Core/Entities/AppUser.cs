using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }

        public Personal Personal { get; set; }
        public Teacher Teacher { get; set; }
    }
}
