using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class OrderConfiguration:IEntityTypeConfiguration<OrderAggregate>
{
    public void Configure(EntityTypeBuilder<OrderAggregate> builder)
    {
        builder.ToTable("order");
        builder.Property(o => o.Id);

        builder.Property(o => o.OrderNumber).HasColumnName("order_number").HasColumnType("text");
        builder.Property(o => o.TotalAmount).HasColumnName("total_amount").HasColumnType("decimal");
        builder.Property(o => o.DiscountAmount).HasColumnName("discount_amount").HasColumnType("decimal");
        builder.Property(o => o.OrderDate).HasColumnName("order_date").HasColumnType("date");

        builder.HasOne(o => o.User).WithMany(u => u.Orders);
        builder.HasOne(o => o.Address).WithMany(a => a.Orders);
        builder.HasMany(o => o.Products).WithMany(p => p.Orders);
    }
}
