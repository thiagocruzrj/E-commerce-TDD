using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDemo.Sales.Domain;

namespace ShopDemo.Catalog.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .HasDefaultValueSql("NEXT VALUE FOR MySequence");

            // 1 : N => Order : OrderItem
            builder.HasMany(c => c.OrderItems)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.Id);

            builder.ToTable("Orders");
        }
    }
}
