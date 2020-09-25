using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmetPizzaPrac3.Data;
using GourmetPizzaPrac3.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GourmetPizzaPrac3.Pages.Purchases
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly GourmetPizzaPrac3.Data.ApplicationDbContext _context;

        public IndexModel(GourmetPizzaPrac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchase { get;set; }

        public async Task OnGetAsync(string sort = "name_asc")
        {
            IQueryable<Purchase> purchases = _context.Purchase
                .Include(p => p.TheCustomer)
                .Include(p => p.ThePizza);

            string _email = User.FindFirst(ClaimTypes.Name).Value;

            purchases = purchases.Where(p => p.TheCustomer.Email == _email);

            switch (sort)
            {
                case "count_asc":
                    purchases = purchases.OrderBy(p => p.PizzaCount);
                    break;
                case "count_desc":
                    purchases = purchases.OrderByDescending(p => p.PizzaCount);
                    break;
                case "name_asc":
                    purchases = purchases.OrderBy(p => p.ThePizza.Name);
                    break;
                case "name_desc":
                    purchases = purchases. OrderByDescending(p => p.ThePizza.Name);
                    break;
                case "price_asc":
                    purchases = purchases.OrderBy(p => (double) p.TotalPrice);
                    break;
                case "price_desc":
                    purchases = purchases.OrderByDescending(p => (double)p.TotalPrice);
                    break;
                default:
                    purchases = purchases.OrderBy(p => p.ID);
                    break;
            }

            ViewData["NextCountOrder"] = sort == "count_asc" ? "count_desc" : "count_asc";
            ViewData["NextNameOrder"] = sort  == "name_asc"  ? "name_desc"  : "name_asc" ;
            ViewData["NextPriceOrder"] = sort == "price_asc" ? "price_desc" : "price_asc";


            Purchase = await purchases.AsNoTracking().ToListAsync();
        }
    }
}
