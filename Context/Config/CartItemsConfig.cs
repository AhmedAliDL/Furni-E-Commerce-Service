using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class CartItemsConfig : IEntityTypeConfiguration<CartItems>
    {
        public void Configure(EntityTypeBuilder<CartItems> builder)
        {
            builder.HasKey(ci => ci.CartItemId);
            builder.Property(ci => ci.CartItemId).ValueGeneratedOnAdd().HasColumnType("int");

            builder.Property(ci => ci.ShoppingCartId).HasColumnType("int");
            builder.Property(ci => ci.Quantity).HasColumnType("int");


            builder.HasOne(ci => ci.ShoppingCart)
                 .WithMany()
                 .HasForeignKey(ci => ci.ShoppingCartId);
                
        }
    }
}
