using Microsoft.EntityFrameworkCore;

namespace TicketModel
{
    public class TicketModelContext : DbContext
    {
        public TicketModelContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Events;Integrated Security=True;
                  Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
                  ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<TicketHolder> TicketHolders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
