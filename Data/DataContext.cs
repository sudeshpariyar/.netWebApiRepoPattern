using Microsoft.EntityFrameworkCore;

namespace RepoPattern.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
