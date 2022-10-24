namespace TicketModel
{
    public class TicketHolder
    {
        public TicketHolder()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
