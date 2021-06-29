using Microsoft.EntityFrameworkCore;

using UniLibProject.Models;

namespace UniLibProject.Data
{
    class ApplicationDbContext : DbContext
    {


        protected override void OnConfiguring(
              DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=products.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
