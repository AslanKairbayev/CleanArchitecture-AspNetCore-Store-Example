using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> FindByName(string userName);
        Task<bool> SignIn(User user, string password);
        Task SignOut();
    }
}
