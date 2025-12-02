using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class CategoriesConfig : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId).ValueGeneratedOnAdd().HasColumnType("int");

            builder.Property(c => c.CategoryName).HasColumnType("nvarchar(50)");

        }
    }
}
