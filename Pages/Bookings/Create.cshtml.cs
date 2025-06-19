using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages_Bookings
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "BusinessName");
            ViewData["StallId"] = new SelectList(_context.Stalls, "Id", "LocationCode");
            ViewData["MarketDayId"] = new SelectList(_context.MarketDays, "Id", "Date");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "BusinessName", Booking.VendorId);
                ViewData["StallId"] = new SelectList(_context.Stalls, "Id", "LocationCode", Booking.StallId);
                ViewData["MarketDayId"] = new SelectList(_context.MarketDays, "Id", "Date", Booking.MarketDayId);
                return Page();
            }

            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
