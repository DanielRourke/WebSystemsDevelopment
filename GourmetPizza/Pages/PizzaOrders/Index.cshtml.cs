using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GourmetPizza.Data;
using GourmetPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace GourmetPizza.Pages.PizzaOrders
{
    public class IndexModel : PageModel
    {
        private readonly GourmetPizza.Data.GourmetPizzaContext _context;

        public IndexModel(GourmetPizza.Data.GourmetPizzaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
 
            PizzaNames = new SelectList(_context.Pizza, "Id" , "Name");

            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public PizzaOrder PizzaOrder { get; set; }

        public SelectList PizzaNames { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            PizzaNames = new SelectList(_context.Pizza, "Id", "Name");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var pizza = await _context.Pizza.SingleOrDefaultAsync(p => p.Id == PizzaOrder.PizzaID);

            //Set Pizza Name based on selection
            ViewData["PizzaName"] = pizza.Name;
            //Set Total price based on count and pizza price
            ViewData["TotalPrice"] = string.Format("{0:C}", PizzaOrder.PizzaCount * pizza.Price);

            return Page();
        }
    }
}
