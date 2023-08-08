using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Access.Data
{
    public class YogaManagementDbContext : DbContext
    {
        public YogaManagementDbContext(DbContextOptions<YogaManagementDbContext> options) : base(options)
        {

        }

        #region DBSet
        public DbSet<Client> Clients { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
