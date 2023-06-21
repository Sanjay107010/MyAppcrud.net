using Microsoft.EntityFrameworkCore;
using MyAppWeb.Models;

namespace MyAppWeb.Data
{
    public class AplicationDBContext:DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext>Options):base(Options) { 
        }
        public DbSet<Category> Categories { get; set; }
    }
}
