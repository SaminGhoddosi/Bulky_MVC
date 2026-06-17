using Bulky.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAcess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }       

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Products { get; set; }
    }
}
