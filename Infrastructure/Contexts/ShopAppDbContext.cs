using Application.Common.Interfaces;
using Domain.Models;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;
namespace Infrastructure.Contexts;

public class ShopAppDbContext : DbContext, IShopAppDbContext
{
    private readonly IConfiguration _configuration;

    public ShopAppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public DbSet<ProductAggregate> Products { get; set; }
    public DbSet<OrderAggregate> Orders { get; set; }
    public DbSet<UserAggregate> Users { get; set; }
    public DbSet<AddressAggregate> Address { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var comnectionString = _configuration.GetConnectionString("DefaultConnection");
        base.OnConfiguring(optionsBuilder);
        var builder = new NpgsqlDataSourceBuilder(comnectionString);
        builder.EnableDynamicJson();
        var dataSource = builder.Build();
        optionsBuilder.UseNpgsql(dataSource);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
