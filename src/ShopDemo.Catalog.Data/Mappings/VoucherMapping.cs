﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopDemo.Sales.Domain;

namespace ShopDemo.Catalog.Data.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .IsRequired()
                .HasColumnType("varchar(100)");

            // 1 : N => Voucher : Pedidos
            builder.HasMany(c => c.Orders)
                .WithOne(c => c.Voucher)
                .HasForeignKey(c => c.VoucherId);

            builder.ToTable("Vouchers");
        }
    }
}
