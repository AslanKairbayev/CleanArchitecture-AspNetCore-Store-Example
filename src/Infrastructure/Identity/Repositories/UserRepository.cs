using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserRepository(UserManager<AppUser> usrMgr, SignInManager<AppUser> signInMgr)
        {
            userManager = usrMgr;
            signInManager = signInMgr;
        }

        public async Task<User> FindByName(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null) return null;
            return new User(user.UserName, user.Id, user.PasswordHash);
        }

        public async Task<bool> SignIn(User user, string password)
        {
            return (await signInManager.PasswordSignInAsync(    
                new AppUser(user.UserName) {Id = user.Id, PasswordHash = user.PasswordHash }
                , password, false, false)).Succeeded;
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }
    }
}
