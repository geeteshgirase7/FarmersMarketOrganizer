using System;
using System.Collections.Generic;

public class MarketDay
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public List<Booking> Bookings { get; set; }
}
