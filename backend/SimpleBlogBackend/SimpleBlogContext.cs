using Microsoft.EntityFrameworkCore;
using SimpleBlogBackend.Models;

namespace SimpleBlogBackend
{
    public class SimpleBlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SimpleBlog.db");
        }
    }
}
