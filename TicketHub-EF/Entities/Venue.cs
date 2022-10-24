namespace TicketModel
{
    public class Venue
    {
        public Venue()
        {
            this.Events = new HashSet<Event>();
            this.Seats = new HashSet<Seat>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
   
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
