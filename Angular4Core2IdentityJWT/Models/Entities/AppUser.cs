using Microsoft.AspNetCore.Identity;

namespace Angular4Core2IdentityJWT.Models.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
