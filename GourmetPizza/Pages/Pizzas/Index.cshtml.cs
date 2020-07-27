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
    public class IndexModel : PageModel
    {
        private readonly GourmetPizza.Data.GourmetPizzaContext _context;

        public IndexModel(GourmetPizza.Data.GourmetPizzaContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizza.ToListAsync();
        }
    }
}
