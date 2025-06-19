using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages_Vendors
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vendor Vendor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Vendor = await _context.Vendors.FindAsync(id);

            if (Vendor == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Vendor == null) return NotFound();

            var vendorToDelete = await _context.Vendors.FindAsync(Vendor.Id);

            if (vendorToDelete != null)
            {
                _context.Vendors.Remove(vendorToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
