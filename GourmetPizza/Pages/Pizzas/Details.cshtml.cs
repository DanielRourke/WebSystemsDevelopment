using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GourmetPizza.Data;
using GourmetPizza.Models;

namespace GourmetPizza.Pages.Pizzas
{
    public class DetailsModel : PageModel
    {
        private readonly GourmetPizza.Data.GourmetPizzaContext _context;

        public DetailsModel(GourmetPizza.Data.GourmetPizzaContext context)
        {
            _context = context;
        }

        public Pizza Pizza { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pizza = await _context.Pizza.FirstOrDefaultAsync(m => m.Id == id);

            if (Pizza == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
