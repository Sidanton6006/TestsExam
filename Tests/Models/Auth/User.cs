using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models.Auth
{
    public class User
    {
        public User()
        {
            this.CreatedTests = new List<Test>();
            this.StartedTests = new List<Test>();
            this.ComplitedTests = new List<Test>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public virtual List<Test> CreatedTests { get; set; }
        public virtual List<Test> StartedTests { get; set; }
        public virtual List<Test> ComplitedTests { get; set; }
    }
}
