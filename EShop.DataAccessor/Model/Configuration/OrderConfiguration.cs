using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.DataAccessor.Model.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Quantity).IsRequired();

            builder.HasOne(order => order.Product)
                    .WithMany(product => product.Orders);
            builder.HasOne(order => order.User)
                    .WithMany(user => user.Orders);
        }
    }
}