using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GourmetPizza.Pages.PizzaTest
{
    public class PurchaseModel : PageModel
    {
        public void OnGet(int pizzaType, int pizzaCount)
        {
            switch (pizzaType)
            {
                case 1:
                    ViewData["Name"] = "BBQ Beef";
                    ViewData["Price"] = pizzaCount * 10.50;
                    break;
                case 2:
                    ViewData["Name"] = "Chicken and Pineapple";
                    ViewData["Price"] = pizzaCount * 8.50;
                    break;
                case 3:
                    ViewData["Name"] = "Pepperoni Feast";
                    ViewData["Price"] = pizzaCount * 9.00;
                    break;
                case 4:
                    ViewData["Name"] = "Vegetarian";
                    ViewData["Price"] = pizzaCount * 7.00;
                    break;

            }
        }
    }
}