using Microsoft.EntityFrameworkCore;

namespace EFPayroll
{
    public class PayDbContext : DbContext
    {
        public PayDbContext()
        { }
        public PayDbContext(DbContextOptions<PayDbContext> opt)
            : base(opt) { }

        public DbSet<Company> Companies { get; set;} = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Contractor> Contractors { get; set; } = null!;
        public DbSet<Intern> Interns => Set<Intern>(); 

        protected override void OnConfiguring(DbContextOptionsBuilder opts)
        {
            if (!opts.IsConfigured)
            {
                opts.UseSqlite(@"Data Source=payroll.dat")
                    .UseLazyLoadingProxies();
            }
            base.OnConfiguring(opts);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Contractor>().ToTable("Contractors");
            builder.Entity<Intern>().ToTable("Interns");
            base.OnModelCreating(builder);
        }

    }
}
