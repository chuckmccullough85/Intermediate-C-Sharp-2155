using Microsoft.EntityFrameworkCore;

namespace EFPayroll
{
    public class PayDbContext : DbContext
    {
        public PayDbContext()
        { }
        public PayDbContext(DbContextOptions<PayDbContext> opt)
            : base(opt) { }

        public DbSet<Company> Companies { get; set;}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Intern> Interns => Set<Intern>();

        protected override void OnConfiguring(DbContextOptionsBuilder opts)
        {
            if (!opts.IsConfigured)
            {
                opts.UseSqlServer(@"Data Source=(localdb)\ProjectModels;
                    Initial Catalog=PayDb2;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;
                    TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
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
