using System;
using System.Linq;
using VoteSystem.Logic.Data;
using VoteSystem.Logic.Models;

namespace VoteSystem.Logic.Services
{
    public class UserService
    {
        public User CheckUserIfLogin(string userName, string password)
        {
            var user = DataCollection.Users
                .SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if (user == null)
                throw new Exception("用户名或密码错误");
            return user;
        }
    }
}
