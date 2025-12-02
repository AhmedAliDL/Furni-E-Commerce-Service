using Furni_E_Commerce_Service.Context.Config;
using Furni_E_Commerce_Service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Furni_E_Commerce_Service.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() : base()
        {
            
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsCartItems> ProductsCartItems { get; set; }
        public DbSet<Coupons> Coupons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var constr = WebApplication.CreateBuilder().Configuration["constr"];

            optionsBuilder.UseSqlServer(constr);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
