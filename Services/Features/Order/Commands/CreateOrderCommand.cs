using Domain.Models;
using MediatR;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Order.Commands;

public class CreateOrderCommand:IRequest
{
    public CreateOrderCommand(int userId ,int orderId,int addressId, List<int> productIds)
    {
        UserId = userId;
        OrderId = orderId;
        AddressId=addressId;
        ProductIds = productIds;
    }
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public int AddressId { get; set; }
    public List<int> ProductIds { get; set; }
    public List<ProductAggregate> Products{ get; set; }
    public virtual AddressAggregate Address { get; set; }
    public virtual UserAggregate User { get; set; }

    public class Handler : IRequestHandler<CreateOrderCommand> 
    {
        private readonly IShopAppDbContext _dbContext;
        public Handler(IShopAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }   
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken) 
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(o => o.Id == request.UserId);
            if (user is null)
            {
                throw new Exception("Kulanıcı Bulunamadı.");
            }
            var address= await _dbContext.Address.FirstOrDefaultAsync(o=>o.Id == request.AddressId);
            {
                if (address is null)
                {
                    throw new Exception("Adres bulunamadı.");
                }
            }
            var products= await _dbContext.Products.Where(o=> request.ProductIds.Contains(o.Id)).ToListAsync(cancellationToken);
            {
                if(products.Count != request.ProductIds.Count)
                {
                    throw new Exception("Ürünler bulunamadı.");
                }

                products.ForEach(o => o.Quantity--);
                await _dbContext.SaveChangesAsync(cancellationToken);
                decimal totalAmount=products.Sum(o=>o.Price);
                string orderNumber;
            }
        }
    }
}
