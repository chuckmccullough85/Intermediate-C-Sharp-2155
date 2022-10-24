namespace TicketModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new TicketModelContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
                try
                {
                    Seed(ctx);
                    ctx.SaveChanges();
                    Console.WriteLine(ctx.Seats.Count());
                    foreach (Venue v in ctx.Venues)
                    {
                        foreach (Seat s in v.Seats)
                            Console.WriteLine(s.Price);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Seed(TicketModelContext ctx)
        {
            //while (ctx.Venues.Count() > 0)
            //{
            //            ctx.Venues.Remove(ctx.Venues.First());
            //          ctx.SaveChanges();
            //  }

            Random rnd = new Random();
            Venue venue = new Venue() { Name = "Kyle Field", Location = "College Station, TX" };
            ctx.Venues.Add(venue);
            short[] sects = { 101, 201, 301, 401 };
            foreach (short sect in sects)
            {
                for (short section = sect; section < sect + 23; section++)
                {
                    for (short row = 1; row < 30; row++)
                    {
                        for (short sn = 1; sn < 20; sn++)
                        {
                            Seat seat = new Seat()
                            {
                                Section = section.ToString(),
                                Number = sn,
                                Rating = (short)rnd.Next(5),
                                Price = rnd.Next(300),
                                Row = row
                            };
                            venue.Seats.Add(seat);
                        }
                    }
                }
            }


        }

    }
}
