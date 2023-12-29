## Overview
In this lab, we will modify our payroll system to support the database.

| | |
| --------- | --------------------------- |
| Exercise Folder | EFPayroll |
| Builds On | [Collections](../Collections) |
 Time to complete | 60 minutes


## Entity framework
Add these packages to your project via NuGet
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Proxies

## Model Updates
Entity framework doesn't do well with interface type properties.
Rename *IPayable* to *Payable* (use the rename tool)
- change from interface to abstract class
- change Pay to public abstract
- add an *Id* auto property (int)

### Company
- add default ctor
- change the IEnumerable Resources to virtual ICollection {get;set;}
- remove the resources field
- update any references to *resources* to *Resources*
- add **override** to Pay()

### HumanResource
- add default ctor
- remove *Pay()*
- add **[NotMapped]** to Tenure


### Employee
- add **[NotMapped]** to LocalTaxFunc
- add default ctor

### Contractor & Intern
- add default ctor

### PayDbContext
- Create a new class *PayDbContext : DbContext*
- Create a DbSet for each entity (company, employee, contractor, intern)
- Override OnConfiguring
    - add sqlserver
    - use proxies
- Create a database in *Sql Server Object Explorer*
- Copy the connection string into db context


```csharp
public class PayDbContext : DbContext
{
    public PayDbContext()
    { }
    public PayDbContext(DbContextOptions<PayDbContext> opt)
        : base(opt) { }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Contractor> Contractors => Set<Contractor>();
    public DbSet<Intern> Interns => Set<Intern>();

    protected override void OnConfiguring(DbContextOptionsBuilder opts)
    {
        if (!opts.IsConfigured)
        {
            opts.UseSqlServer(@"*connection string*")
                .UseLazyLoadingProxies();
        }
        base.OnConfiguring(opts);
    }
 }
 ```


### CompanyDbTest
- Add a new class for testing the database.
- See below for a simple test class.
- Run the *GetAllCompanies* test to generate a database and verify the EF mappings
- Notice the database schema in *SQL Server Object Explorer*


```csharp
public class CompanyDbTest : IDisposable
{
    PayDbContext ctx;
    public CompanyDbTest()
    {
        ctx = new PayDbContext();
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
        Seed(ctx);
    }
    [Fact]
    public void TestGetAllCompanies()
    {
        var c = ctx.Companies.First();
        Assert.Equal(3, c.Resources.Count());
    }

    public void Dispose()
    {
        ctx.Dispose();
    }
    private static void Seed(PayDbContext ctx)
    {
        Company c1 = new ("Strickland Propane", "12-3456");
        Company c2 = new ("Arlen Public Library", "98-7654");
        Employee e1 = new ("Hank", "Hill", 200, DateTime.Today.AddYears(-10));
        Contractor ctr = new ("Peggy", "Hill", 50, DateTime.Parse("2005-10-31"));
        Intern intern = new ("Luann", "Platter", DateTime.Today.AddMonths(-18));
        c1.Hire(e1);
        c1.Hire(ctr);
        c2.Hire(intern);
        ctx.Companies.Add(c1);
        ctx.Companies.Add(c2);
        ctx.SaveChanges();
    }

}
```


### Configuring Mappings

We can configure the mappings in the *OnModelCreating* method of the *DbContext*.

- Override the *OnModelCreating* method in *PayDbContext*.
- Using the parameter (modelBilder), configure mappings to map the entities to separate tables
    -  Use *Entity<T>()* to select the entity and *ToTable()* to specify the table name
    - Use *Ignore()* to ignore properties that are not mapped to the database

Re-run the db test to re-create the database and verify the mappings.

```chsarp
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
```
