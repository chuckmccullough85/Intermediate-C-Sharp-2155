namespace TicketModel
{
    public class Seat
    {
        public Seat()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        public string Section { get; set; }
        public short Row { get; set; }
        public short Number { get; set; }
        public float Price { get; set; }
        public string? Comment { get; set; }
        public short Rating { get; set; }
        public virtual Venue? Venue { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
