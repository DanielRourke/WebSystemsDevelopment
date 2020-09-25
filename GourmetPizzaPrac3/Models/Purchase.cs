using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GourmetPizzaPrac3.Models
{
    public class Purchase
    {
        
        public int ID { get; set; }

        public int PizzaID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Range(1,80)]
        public int PizzaCount { get; set; }

        [DataType(DataType.Currency)]
        [Range(1.00, 1000.00)]
        public decimal TotalPrice { get; set; }

        public Pizza ThePizza { get; set; }

        public Customer TheCustomer { get; set; }


    }
}
