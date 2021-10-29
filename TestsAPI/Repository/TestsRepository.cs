using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.DBContext;
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
        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users;
        }
        public User Register(User user)
        {
            if (user == null) return null;
            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            return _ctx.Users.Find(user);
        }
    }
}
