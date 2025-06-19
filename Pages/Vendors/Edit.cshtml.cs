using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages_Vendors
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vendor Vendor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Vendor = await _context.Vendors.FindAsync(id);
            if (Vendor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(Vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Vendors.Any(v => v.Id == Vendor.Id))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
