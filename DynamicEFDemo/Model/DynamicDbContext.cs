using Microsoft.EntityFrameworkCore;
namespace DynamicEFDemo.Model
{
    public class DynamicDbContext: DbContext
    {
        private readonly string _connectionString;

        public DynamicDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the Employee entity to the tblEmp table in the dbo schema
            modelBuilder.Entity<Employee>().ToTable("tblEmp", "dbo");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
