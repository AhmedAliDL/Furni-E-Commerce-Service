using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class ProductsConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductId).ValueGeneratedOnAdd().HasColumnType("int");

            builder.Property(p => p.ProductName).HasColumnType("nvarchar(50)");
            builder.Property(p => p.Description).HasColumnType("text");
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.StockQuantity).HasColumnType("int");
            builder.Property(p => p.CategoryId).HasColumnType("int");
            builder.Property(p => p.ImageUrl).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.CreateDate).HasColumnType("datetime");
            builder.Property(p => p.IsActive).HasColumnType("bit");

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);


        }
    }
}
