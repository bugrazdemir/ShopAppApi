using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configuration;
public class AddressConfiguration:IEntityTypeConfiguration<AddressAggregate>
{
    public void Configure(EntityTypeBuilder<AddressAggregate> builder)
    {
        builder.ToTable("address");
        builder.HasKey(a=>a.Id);

        builder.Property(a=>a.Address).HasColumnName("address").HasColumnType("varchar(250)").IsRequired();
        builder.Property(a => a.AddressName).HasColumnName("addressName").HasColumnType("varchar(50)").IsRequired();
       
        
        builder.HasOne(a => a.User).WithMany(u => u.Addresses);
        builder.HasMany(a=>a.Orders).WithOne(o=>o.Address);
    }
}
