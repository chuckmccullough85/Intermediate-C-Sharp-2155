using Microsoft.EntityFrameworkCore;

namespace EFPayroll;

public class PayDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<Intern> Interns { get; set; }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("""
            Server=(localdb)\mssqllocaldb;Database=Payroll;
            Trusted_Connection=True;
            """);
        optionsBuilder.UseLazyLoadingProxies();
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .ToTable("Company");

        modelBuilder.Entity<Employee>()
            .ToTable("Employee")
            .Ignore(e => e.LocalTaxMethod);
           
        modelBuilder.Entity<Contractor>()
            .ToTable("Contractor");

        modelBuilder.Entity<Intern>()
            .ToTable("Intern");
        modelBuilder.Entity<HumanResource>()
            .Ignore(e => e.Tenure);

    }
}
