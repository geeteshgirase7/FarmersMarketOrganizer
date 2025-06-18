using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Vendor
{
    public int Id { get; set; }

    [Required]
    public string BusinessName { get; set; }

    public string ContactName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public List<Booking> Bookings { get; set; }
}
