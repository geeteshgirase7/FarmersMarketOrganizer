using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Booking = await _context.Bookings
                .Include(b => b.Vendor)
                .Include(b => b.Stall)
                .Include(b => b.MarketDay)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (Booking == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
