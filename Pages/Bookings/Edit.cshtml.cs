using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages_Bookings
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public SelectList VendorOptions { get; set; }
        public SelectList StallOptions { get; set; }
        public SelectList MarketDayOptions { get; set; }

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

            await PopulateDropdownsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownsAsync();
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Bookings.Any(e => e.Id == Booking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task PopulateDropdownsAsync()
        {
            VendorOptions = new SelectList(await _context.Vendors.ToListAsync(), "Id", "BusinessName");
            StallOptions = new SelectList(await _context.Stalls.ToListAsync(), "Id", "LocationCode");
            MarketDayOptions = new SelectList(await _context.MarketDays.ToListAsync(), "Id", "Date");
        }
    }
}
