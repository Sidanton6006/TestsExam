using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Models.Auth;

namespace TestsAPI.Repository
{
    public interface ITestsRepository
    {
        IEnumerable<User> GetAllUsers();
        User Register(User user);
        User GetUserByEmail(string email);
        User GetUserById(int id);
        bool DeleteUser(string email);
    }
}
