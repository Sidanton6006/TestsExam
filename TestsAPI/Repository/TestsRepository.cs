using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.DBContext;
using Tests.Models;
using Tests.Models.Auth;

namespace TestsAPI.Repository
{
    public class TestsRepository : ITestsRepository
    {
        private readonly TasksDbContext _ctx;

        public TestsRepository(TasksDbContext ctx)
        {
            _ctx = ctx;
        }

        #region Auth
        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }
        public User Register(User user)
        {
            if (user == null) return null;
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
            var findUser = _ctx.Users.Find(user.Id);
            if (findUser == null) return null;
            return findUser;
        }
        public bool DeleteUser(string email)
        {
            if (email == null) return false;
            var user = _ctx.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;
            _ctx.Users.Remove(user);
            var res = _ctx.SaveChanges();
            if (res < 0) return false;
            return true;
        }
        public User GetUserByEmail(string email)
        {
            if (email == null) return null;
            var user = _ctx.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return null;
            return user;
        }
        public User GetUserById(int id)
        {
            if (id <= 0) return null;
            var user = _ctx.Users.Find(id);
            if (user == null) return null;
            return user;
        }
        #endregion

        #region Tests
        public IEnumerable<Test> GetAllTests()
        {
            return _ctx.Tests;
        }
        #endregion
    }
}
