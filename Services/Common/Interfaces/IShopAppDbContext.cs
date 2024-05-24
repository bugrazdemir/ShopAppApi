using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces;

public interface IShopAppDbContext
{
    DbSet<ProductAggregate> Products { get; set; }
    DbSet<OrderAggregate> Orders { get; set; }
    DbSet<AddressAggregate> Address { get; set; }
    DbSet<UserAggregate> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
