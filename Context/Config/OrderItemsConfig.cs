using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class OrderItemsConfig : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.HasKey(oi => oi.OrderItemId);
            builder.Property(oi => oi.OrderItemId).ValueGeneratedOnAdd().HasColumnType("int");

            builder.Property(oi => oi.OrderId).HasColumnType("int");
            builder.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(oi => oi.Quantity).HasColumnType("int");
            builder.Property(oi => oi.ProductId).HasColumnType("int");

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);
            
            builder.HasOne(oi => oi.Order)
                .WithMany()
                .HasForeignKey(oi => oi.OrderId);
        }
    }
}
