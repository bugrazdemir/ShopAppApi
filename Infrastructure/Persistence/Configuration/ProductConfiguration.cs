using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ProductConfiguration:IEntityTypeConfiguration <ProductAggregate>
{
    public void Configure(EntityTypeBuilder<ProductAggregate> builder)
    {
        builder.ToTable("product");
        builder.HasKey(p=>p.Id);

        builder.Property(p=>p.ProductName).HasColumnName("product_name").HasColumnType("varchar(255)");
        builder.Property(p=>p.Description).HasColumnName("description").HasColumnType("text");
        builder.Property(p=>p.Price).HasColumnName("price").HasColumnType("decimal");
        builder.Property(p => p.Quantity).HasColumnName("quantity").HasColumnType("decimal");
        builder.Property(p => p.ProductUploadDate).HasColumnName("product_upload_date").HasColumnType("date");
    }
}
