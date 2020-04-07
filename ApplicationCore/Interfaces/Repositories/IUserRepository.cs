using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User FindByName(string userName);
        bool CheckPassword(User user, string password);
    }
}
