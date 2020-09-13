using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmetPizza.Data;
using GourmetPizza.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GourmetPizza.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly GourmetPizza.Data.GourmetPizzaContext _context;

        public IndexModel(GourmetPizza.Data.GourmetPizzaContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Customer> customers = _context.Customer; 

            if(!string.IsNullOrEmpty(SearchString))
            {
                customers = customers.Where(s => s.FamilyName.Contains(SearchString) || s.GivenName.Contains(SearchString));
            }

            Customer = await customers.ToListAsync();
        }
    }
}
