using Application.Common.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Address.Queries;

public class GetAddressQuery:IRequest<List<AddressAggregate>>
{
    public class Handler:IRequestHandler<GetAddressQuery, List<AddressAggregate>>
    {
        private readonly IShopAppDbContext _dbContext;

        public Handler(IShopAppDbContext dbContext) 
        {
            _dbContext=dbContext;
        }
        public async Task<List<AddressAggregate>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        { 
            var addresses= await _dbContext.Address.ToListAsync(cancellationToken);
            return addresses;
        } 
    }
}
