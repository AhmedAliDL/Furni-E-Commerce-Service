using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class CouponConfig : IEntityTypeConfiguration<Coupons>
    {
        public void Configure(EntityTypeBuilder<Coupons> builder)
        {
            builder.HasKey(c => c.CouponId);
            builder.Property(c => c.CouponId).ValueGeneratedOnAdd();

            builder.Property(c => c.CouponCode).HasColumnType("nvarchar(100)");
        }
    }
}
