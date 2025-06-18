using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Stall> Stalls { get; set; }
    public DbSet<MarketDay> MarketDays { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}
