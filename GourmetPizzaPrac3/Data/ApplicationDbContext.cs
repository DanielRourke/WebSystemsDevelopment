using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GourmetPizzaPrac3.Models;

namespace GourmetPizzaPrac3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GourmetPizzaPrac3.Models.Pizza> Pizza { get; set; }
        public DbSet<GourmetPizzaPrac3.Models.Customer> Customer { get; set; }
        public DbSet<GourmetPizzaPrac3.Models.Purchase> Purchase { get; set; }
    }
}
