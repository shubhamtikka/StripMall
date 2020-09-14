using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StripMall.Models;


namespace StripMall.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShopType> shopTypes { get; set; }



        public DbSet<Items> S_items { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoppingCartItem>()
       .HasKey(c => new { c.CustomerId, c.Item });
                
        }
    }
}
