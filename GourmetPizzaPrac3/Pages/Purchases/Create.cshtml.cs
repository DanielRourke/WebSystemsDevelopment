using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GourmetPizzaPrac3.Data;
using GourmetPizzaPrac3.Models;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Contracts;

namespace GourmetPizzaPrac3.Pages.Purchases
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly GourmetPizzaPrac3.Data.ApplicationDbContext _context;

        public CreateModel(GourmetPizzaPrac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PizzaID"] = new SelectList(_context.Pizza, "Id", "Name");
 

            return Page();
        }

        [BindProperty]
        public PurchaseViewModel PurchaseViewModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string _email = User.FindFirst(ClaimTypes.Name).Value;

            Purchase purchase = new Purchase
            {
                    CustomerEmail = _email,
                    PizzaID = PurchaseViewModel.PizzaID,
                    PizzaCount = PurchaseViewModel.PizzaCount,
                    TheCustomer = await _context.Customer.FindAsync(_email),
                    ThePizza = await _context.Pizza.FindAsync(PurchaseViewModel.PizzaID)

            };

            
            purchase.TotalPrice = purchase.PizzaCount * purchase.ThePizza.Price;
            
            PurchaseViewModel.TotalPrice = purchase.PizzaCount * purchase.ThePizza.Price;
            PurchaseViewModel.Name = purchase.ThePizza.Name;

            var results = new List<ValidationResult>();
            
            //validate price ??? do more ??
            if(!Validator.TryValidateObject(purchase, new ValidationContext(purchase), results))
            {
                return Page();
            }

              _context.Purchase.Add(purchase);
              await _context.SaveChangesAsync();
            ViewData["SuccessDB"] = "success";

            return Page();
        }
    }
}
