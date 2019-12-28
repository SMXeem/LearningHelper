using System.Data.Entity;
using LearningHelper.Models;

namespace LearningHelper.Utility
{
    public class LearningContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<ChatBox> ChatBox { get; set; }
    }
}