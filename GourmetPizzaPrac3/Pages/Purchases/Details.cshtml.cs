using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmetPizzaPrac3.Data;
using GourmetPizzaPrac3.Models;

namespace GourmetPizzaPrac3.Pages.Purchases
{
    public class DetailsModel : PageModel
    {
        private readonly GourmetPizzaPrac3.Data.ApplicationDbContext _context;

        public DetailsModel(GourmetPizzaPrac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Purchase Purchase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Purchase = await _context.Purchase
                .Include(p => p.TheCustomer)
                .Include(p => p.ThePizza).FirstOrDefaultAsync(m => m.ID == id);

            if (Purchase == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
