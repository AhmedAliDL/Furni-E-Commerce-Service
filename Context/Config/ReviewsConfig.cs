using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class ReviewsConfig : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
            builder.HasKey(r => r.ReviewId);
            builder.Property(r => r.ReviewId).ValueGeneratedOnAdd().HasColumnType("int");

            builder.Property(r => r.UserId).HasColumnType("nvarchar(450)");
            builder.Property(r => r.ProductId).HasColumnType("int");
            builder.Property(r => r.Rating).HasColumnType("int");
            builder.Property(r => r.Comment).HasColumnType("text");
            builder.Property(r => r.ReviewDate).HasColumnType("datetime");

            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Product)
                .WithMany()
                .HasForeignKey(r => r.ProductId);

        }
    }
}
