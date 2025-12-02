using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class OrdersConfig : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId).ValueGeneratedOnAdd().HasColumnType("int");

            builder.Property(o => o.UserId).HasColumnType("nvarchar(450)");
            builder.Property(o => o.OrderDate).HasColumnType("datetime");
            builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Property(o => o.OrderStatus).HasColumnType("nvarchar(30)");
            builder.Property(o => o.ShippingAddress).HasColumnType("nvarchar(450)");
            builder.Property(o => o.PaymentStatus).HasColumnType("nvarchar(50)");

            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);
        }
    }
}
