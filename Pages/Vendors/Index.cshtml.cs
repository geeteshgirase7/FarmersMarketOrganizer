using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmersMarketOrganizer.Data;
using FarmersMarketOrganizer.Models;

namespace FarmersMarketOrganizer.Pages.Vendors
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vendor> Vendor { get; set; } = new List<Vendor>();

        public async Task OnGetAsync()
        {
            Vendor = await _context.Vendors.ToListAsync();
        }
    }
}
