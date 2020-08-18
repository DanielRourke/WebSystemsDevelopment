using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmetPizza.Data;
using GourmetPizza.Models;

namespace GourmetPizza.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly GourmetPizza.Data.GourmetPizzaContext _context;

        public DetailsModel(GourmetPizza.Data.GourmetPizzaContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
