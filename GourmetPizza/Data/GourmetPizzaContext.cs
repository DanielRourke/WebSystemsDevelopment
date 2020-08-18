using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GourmetPizza.Models;

namespace GourmetPizza.Data
{
    public class GourmetPizzaContext : DbContext
    {
        public GourmetPizzaContext (DbContextOptions<GourmetPizzaContext> options)
            : base(options)
        {
        }

        public DbSet<GourmetPizza.Models.Pizza> Pizza { get; set; }

        public DbSet<GourmetPizza.Models.Customer> Customer { get; set; }
    }
}
