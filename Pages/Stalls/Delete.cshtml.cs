using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketOrganizer.Pages_Stalls
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stall Stall { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stall = await _context.Stalls.FirstOrDefaultAsync(m => m.Id == id);

            if (stall is not null)
            {
                Stall = stall;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stall = await _context.Stalls.FindAsync(id);
            if (stall != null)
            {
                Stall = stall;
                _context.Stalls.Remove(Stall);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
