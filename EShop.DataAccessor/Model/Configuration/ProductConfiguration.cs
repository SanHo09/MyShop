using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DataAccessor.Model.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Id).ValueGeneratedOnAdd();
            builder.Property(product => product.Name).IsRequired().HasMaxLength(250);
            builder.Property(product => product.Price).IsRequired();
            builder.Property(product => product.Stock).IsRequired();
            builder.Property(product => product.IsDeleted).IsRequired()
                                                     .HasDefaultValue(false);
            builder.Property(product => product.Sold).IsRequired()
                                                     .HasDefaultValue(0);

            builder.HasOne(product => product.category).WithMany(Category => Category.Products);   
        }
    }
}