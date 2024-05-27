using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration;

public  class UserConfiguration: IEntityTypeConfiguration<UserAggregate>
{
    public void Configure(EntityTypeBuilder<UserAggregate> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name).HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("last_name").HasColumnType("varchar(50)").IsRequired();
        builder.Property(u => u.Email).HasColumnName("email").HasColumnType("varchar(50)").IsRequired();
        builder.Property(u => u.Phone).HasColumnName("phone").HasColumnType("varchar(13)").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("created_date").HasColumnType("date");

        builder.HasMany(u => u.Addresses).WithOne(a => a.User);
        builder.HasMany(u => u.Orders).WithOne(o => o.User);

    }
}
