using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class User
    {
        public string Id { get; }
        public string UserName { get; }
        public string PasswordHash { get; }

        public User(string userName, string id = null, string passwordHash = null)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
        }
    }
}
