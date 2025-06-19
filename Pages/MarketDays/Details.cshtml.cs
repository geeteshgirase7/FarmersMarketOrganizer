using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketOrganizer.Pages_MarketDays
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public MarketDay MarketDay { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marketday = await _context.MarketDays.FirstOrDefaultAsync(m => m.Id == id);

            if (marketday is not null)
            {
                MarketDay = marketday;

                return Page();
            }

            return NotFound();
        }
    }
}
