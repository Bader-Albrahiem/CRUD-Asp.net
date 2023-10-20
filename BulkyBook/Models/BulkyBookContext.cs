using Microsoft.EntityFrameworkCore;
namespace BulkyBook.Models
{
    public class BulkyBookContext : DbContext
    {
        public DbSet<Category> category { get; set; }

        public BulkyBookContext(DbContextOptions options) : base(options)
        {

        }
    }
}
