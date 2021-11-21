using Microsoft.EntityFrameworkCore;
using TutoASP6.Models;

namespace TutoASP6.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }

    }
}
