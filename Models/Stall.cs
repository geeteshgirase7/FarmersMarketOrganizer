using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Stall
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]  // ✅ Set a max length instead of 'max'
    public string LocationCode { get; set; }

    [MaxLength(500)]  // ✅ Set a length to avoid SQLite crash
    public string Description { get; set; }

    public List<Booking> Bookings { get; set; }
}
