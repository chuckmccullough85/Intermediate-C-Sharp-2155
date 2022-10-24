
namespace TicketModel
{
    public  class Ticket
    {
        public int Id { get; set; }
        public float Cost { get; set; }
        public SeatStatus Status { get; set; }
    
        public virtual TicketHolder? TicketHolder { get; set; }
        public virtual Event? Event { get; set; }
        public virtual Seat? Seat { get; set; }
    }
}
