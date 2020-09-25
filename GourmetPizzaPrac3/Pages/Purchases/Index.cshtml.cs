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
    public class IndexModel : PageModel
    {
        private readonly GourmetPizzaPrac3.Data.ApplicationDbContext _context;

        public IndexModel(GourmetPizzaPrac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchase { get;set; }

        public async Task OnGetAsync()
        {
            Purchase = await _context.Purchase
                .Include(p => p.TheCustomer)
                .Include(p => p.ThePizza).ToListAsync();
        }
    }
}
