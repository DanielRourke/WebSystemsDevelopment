using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GourmetPizzaPrac3.Models
{
    public class PizzaCountStatistic
    {
        [DisplayName("Pizza Count")]
        public int PizzaCount { get; set; }

        [DisplayName("Purchase Count")]
        public int PurchaseCount { get; set; }

    }
}
