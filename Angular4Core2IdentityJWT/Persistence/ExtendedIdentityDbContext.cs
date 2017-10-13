using Angular4Core2IdentityJWT.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Angular4Core2IdentityJWT.Persistence
{
    public class ExtendedIdentityDbContext: IdentityDbContext
    {
        public ExtendedIdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OtherUser> OtherUsers { get; set; }
    }

    
}
