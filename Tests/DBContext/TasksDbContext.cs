using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Tests.Models;
using Tests.Models.Auth;

namespace Tests.DBContext
{
    public partial class TasksDbContext : DbContext
    {
        public TasksDbContext()
            : base("name=TasksDbContext")
        {
            Database.SetInitializer(new Initializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Ask> Asks { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
