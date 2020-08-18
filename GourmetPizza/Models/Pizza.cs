using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GourmetPizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z\d _]{3,19}", ErrorMessage = "The pizza name " +
            "field is required, and can only consists of English letters, digits, " +
            "spaces and underscore, and has a length between 3 characters and 20 " +
            "characters inclusive.")]
        public string Name { get; set; }

        [Display(Name = "Price Each")]
        [DataType(DataType.Currency)]
        [Range(5.00,20.00, ErrorMessage = "The pizza price should be in the range" +
            " from $5.00 to $20.00 inclusive.")]
        public decimal Price { get; set; }

    }
}
