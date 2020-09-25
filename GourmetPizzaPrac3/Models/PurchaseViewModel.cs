using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GourmetPizzaPrac3.Models
{
    public class PurchaseViewModel
    {
        [Required]
        public int PizzaID { get; set; }

        [Required]
        [Range(1, 80)]
        public int PizzaCount { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
        public string Name { get; set; }
    }
}
