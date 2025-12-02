using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class PaymentsConfig : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.HasKey(p => p.PaymentId);
            builder.Property(p => p.PaymentId).ValueGeneratedOnAdd().HasColumnType("int");

            builder.Property(p => p.OrderId).HasColumnType("int");
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PaymentMethod).HasColumnType("nvarchar(50)");
            builder.Property(p => p.PaymentStatus).HasColumnType("nvarchar(50)");
            builder.Property(p => p.PaymentDate).HasColumnType("datetime");

            builder.HasOne(p => p.Order)
                .WithOne()
                .HasForeignKey<Payments>(p => p.OrderId);
        }
    }
}
