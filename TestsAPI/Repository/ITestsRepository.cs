using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Models;
using Tests.Models.Auth;

namespace TestsAPI.Repository
{
    public interface ITestsRepository
    {
        #region Auth
        IEnumerable<User> GetAllUsers();
        User Register(User user);
        User GetUserByEmail(string email);
        User GetUserById(int id);
        bool DeleteUser(string email);
        #endregion

        #region Tests
        IEnumerable<Test> GetAllTests();
        #endregion
    }
}
