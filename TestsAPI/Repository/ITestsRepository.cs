using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Models.Auth;

namespace TestsAPI.Repository
{
    interface ITestsRepository
    {
        public User Register(User user);
    }
}
