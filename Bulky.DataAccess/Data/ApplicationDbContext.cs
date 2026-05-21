using Bulky.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }       

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Products { get; set; }
    }
}
