using mea.Models;
using Microsoft.EntityFrameworkCore;

namespace mea.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
