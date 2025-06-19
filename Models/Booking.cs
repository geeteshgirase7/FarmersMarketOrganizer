public class Booking
{
    public int Id { get; set; }

    public int VendorId { get; set; }
    public Vendor Vendor { get; set; }

    public int StallId { get; set; }
    public Stall Stall { get; set; }

    public int MarketDayId { get; set; }
    public MarketDay MarketDay { get; set; }

    public bool IsConfirmed { get; set; }
}
