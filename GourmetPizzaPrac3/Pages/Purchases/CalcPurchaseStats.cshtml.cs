using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GourmetPizzaPrac3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GourmetPizzaPrac3.Pages.Purchases
{
    [Authorize]
    public class CalcPurchaseStatsModel : PageModel
    {
        
        private readonly GourmetPizzaPrac3.Data.ApplicationDbContext _context;

        public CalcPurchaseStatsModel(GourmetPizzaPrac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PizzaCountStatistic> PizzaCountStats;

        public async Task<IActionResult> OnGetAsync()
        {
            var purchases = _context.Purchase.GroupBy(p => p.PizzaCount);
 

            PizzaCountStats = await purchases.Select(p => new PizzaCountStatistic
            { PizzaCount = p.Key, PurchaseCount = p.Count() }).AsNoTracking().ToListAsync();

            return Page();
        }
    }
}
