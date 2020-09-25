using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GourmetPizzaPrac3.Data;
using GourmetPizzaPrac3.Models;
using System.Security.Claims;

namespace GourmetPizzaPrac3.Pages.Customers
{
    public class MyDetailsModel : PageModel
    {
        private readonly GourmetPizzaPrac3.Data.ApplicationDbContext _context;

        public MyDetailsModel(GourmetPizzaPrac3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerViewModel CustomerDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //get logged on user email
            //ALSO THROWS NULL IF NO ONE LOGGED IN!!!
            string _email = User.FindFirst(ClaimTypes.Name).Value;

           // string _email = User.FindFirstValue(ClaimTypes.Name);

            Customer Customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if(Customer == null)
            {
                ViewData["ExistInDB"] = "false";
            }
            else
            {
                ViewData["ExistInDB"] = "true";
                CustomerDetails = new CustomerViewModel
                {
                    GivenName = Customer.GivenName,
                    FamilyName = Customer.FamilyName,
                    DateOfBirth = Customer.DateOfBirth,
                    Mobile = Customer.Mobile,
                    PostCode = Customer.PostCode
                };
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            //get logged on user email
            string _email = User.FindFirst(ClaimTypes.Name).Value;

            Customer Customer = await _context.Customer.FirstOrDefaultAsync(m => m.Email == _email);

            if (Customer == null)
            {
                Customer = new Customer
                {
                    Email = _email
                };
            }

            Customer.GivenName = CustomerDetails.GivenName;
            Customer.FamilyName = CustomerDetails.FamilyName;
            Customer.DateOfBirth = CustomerDetails.DateOfBirth;
            Customer.Mobile = CustomerDetails.Mobile;
            Customer.PostCode = CustomerDetails.PostCode;

            if (CustomerExists(Customer.Email))
            {
                _context.Attach(Customer).State = EntityState.Modified;
            }
            else
            {
                _context.Customer.Add(Customer);
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            ViewData["SuccessDB"] = "success";
            return Page();
        }

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.Email == id);
        }
    }
}
