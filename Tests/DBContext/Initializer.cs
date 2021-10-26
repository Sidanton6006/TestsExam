using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.DBContext
{
    public class Initializer : DropCreateDatabaseAlways<TasksDbContext>
    {
        protected override void Seed(TasksDbContext _ctx)
        {
            base.Seed(_ctx);

            
        }
    }
}
