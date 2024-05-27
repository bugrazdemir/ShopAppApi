using Domain.Models;
using MediatR;
using Application.Common.Interfaces;

namespace Application.Features.Address.Queries;

public class GetAddressByIdQuery:IRequest<AddressAggregate>
{
    public GetAddressByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }

    public class Handler : IRequestHandler<GetAddressByIdQuery, AddressAggregate>
    {
        private readonly IShopAppDbContext _dbContext;

        public Handler(IShopAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddressAggregate> Handle(GetAddressByIdQuery request,CancellationToken cancellationToken)
        {
            var address= await _dbContext.Address.FindAsync(request.Id,cancellationToken);

            if (address is null) 
            {
                throw new Exception("Adres bulunamadı.");
            }

            return address; 
        }
    }
}
