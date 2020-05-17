using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser(string userName) : base(userName)
        { }
    }
}
