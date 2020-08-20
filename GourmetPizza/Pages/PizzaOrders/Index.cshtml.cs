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

        public async Task<IActionResult> OnGetAsync()
        {
            ////Linq query to get pizza names and id
            var queryPizzaNames = from p in _context.Pizza
                         select p;

            PizzaNames = new SelectList(await queryPizzaNames.ToListAsync(), "Id" , "Name");

            return Page();
        }

        [BindProperty]
        public PizzaOrder PizzaOrder { get; set; }

        public SelectList PizzaNames { get; set; }

        [TempData]
        public string Credit { get; set; }

        [TempData]
        public string PizzaName { get; set; }

        [TempData]
        public int PizzaCount { get; set; }

        [TempData]
        public string Price { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var queryPizza = from p in _context.Pizza
                             where p.Id == PizzaOrder.PizzaFK
                             select p;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PizzaOrder.Add(PizzaOrder);

            PizzaCount = PizzaOrder.PizzaCount;
            PizzaName = queryPizza.Select(x => x.Name).Single();
            Credit = PizzaOrder.CreditCardNumber.Substring(15);
            Price = string.Format("{0:C}",PizzaCount * queryPizza.Select(x => x.Price).Single());

            await _context.SaveChangesAsync();

            return RedirectToPage("./acknowledgement");
        }
    }
}
