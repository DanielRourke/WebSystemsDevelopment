using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GourmetPizza.Models
{
    public class PizzaOrder
    {
        public int PizzaOrderID { get; set; }

        [Required]
        [DisplayName("Select Pizza")]
        [ForeignKey("AuthorFK")]
        public int PizzaFK { get; set; }

        [Required]
        [DisplayName("Credit Card")]
        [DataType(DataType.CreditCard)]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$", ErrorMessage = "Must be 16 digits in" +
            " the form xxxx xxxx xxxx xxxx")]
        public string CreditCardNumber { get; set; }
        
        [Required]
        [Range(1,10, ErrorMessage = "Minimum 1 and Maximum 10")]
        public int PizzaCount { get; set; }
    }
}
