using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages_Vendors
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Vendor Vendor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Vendor = await _context.Vendors.FindAsync(id);

            if (Vendor == null) return NotFound();

            return Page();
        }
    }
}
