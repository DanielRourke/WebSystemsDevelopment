using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GourmetPizza.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        
        [Required]
        [RegularExpression(@"[A-Za-z-']{2,20}", ErrorMessage = "The family " +
            "name field is required, and can only consists of English letters," +
            " hyphen and apostrophe, and has a length between 2 characters and" +
            " 20 characters inclusive.")]
        public string FamilyName{ get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z-']{2,20}", ErrorMessage = "The given " +
    "name field is required, and can only consists of English letters," +
    " hyphen and apostrophe, and has a length between 2 characters and" +
    " 20 characters inclusive.")]
        public string  GivenName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^04[\d]{2} [\d]{3} [\d]{3}$", ErrorMessage = "Phone number" +
            " must be formated 04xx xxx xxx, i.e., there must be 04 followed by 2 digits," +
            "then a space, then 3 digits, then another space and finally 3 digits")]
        public string Mobile { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-8][0-9]{3}$", ErrorMessage = "PostCode must be 4 digits" +
            " and must not start with 9")]
        public string PostCode { get; set; }
    }
}
