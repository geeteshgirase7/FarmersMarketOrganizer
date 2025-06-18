using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Stall
{
    public int Id { get; set; }

    [Required]
    public string LocationCode { get; set; }  // e.g., A1, B3, etc.

    public string Description { get; set; }

    public List<Booking> Bookings { get; set; }
}
