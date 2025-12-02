using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(sc => sc.CartId);
            builder.Property(sc => sc.CartId).ValueGeneratedOnAdd();

            builder.Property(sc => sc.UserId).HasColumnType("nvarchar(450)");
            builder.Property(sc => sc.CreatedDate).HasColumnType("datetime");

            builder.HasOne(sc => sc.User)
                .WithOne()
                .HasForeignKey<ShoppingCart>(sc => sc.UserId);
        }
    }
}
