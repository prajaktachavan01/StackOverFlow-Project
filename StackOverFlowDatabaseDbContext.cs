using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace StackOverFlowProject.DomainModel
{
    public class StackOverFlowDatabaseDbContext  : DbContext
    {
        public DbSet<Languages> Languages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
