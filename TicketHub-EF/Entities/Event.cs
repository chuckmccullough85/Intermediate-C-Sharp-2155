
namespace TicketModel
{
   
    public  class Event
    {
        public Event()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime StartTime { get; set; }    
        public virtual Venue? Venue { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
