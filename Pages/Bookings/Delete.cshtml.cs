using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Booking = await _context.Bookings.FindAsync(id);

            if (Booking != null)
            {
                _context.Bookings.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
