using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> userManager;

        public UserRepository(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }

        public async Task<User> FindByName(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);

            return new User(user.UserName, user.Id, user.PasswordHash);
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await userManager.CheckPasswordAsync(
                new AppUser {Id = user.Id, UserName = user.UserName, PasswordHash = user.PasswordHash }
                , password);
        }

        
    }
}
