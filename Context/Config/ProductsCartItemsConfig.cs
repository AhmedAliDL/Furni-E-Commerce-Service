using Furni_E_Commerce_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Furni_E_Commerce_Service.Context.Config
{
    public class ProductsCartItemsConfig : IEntityTypeConfiguration<ProductsCartItems>
    {
        public void Configure(EntityTypeBuilder<ProductsCartItems> builder)
        {
            builder.HasKey(pci => new {pci.ProductsId,pci.CartItemsId});

            builder.HasOne(pci => pci.Products)
               .WithMany(p => p.ProductsCartItems)
               .HasForeignKey(pci => pci.ProductsId);

            builder.HasOne(pci => pci.CartItems)
                .WithMany(ci => ci.ProductsCartItems)
                .HasForeignKey(pci => pci.CartItemsId);


        }
    }
}
