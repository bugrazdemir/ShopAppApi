using Domain.Models;
using Application.Common.Interfaces;
using MediatR;
using System.Numerics;
using System.Xml.Linq;
namespace Application.AddPart.Commands;

public class AddAddressCommand : IRequest<AddressAggregate>
{
    public AddAddressCommand(string street, string city, string state, string postalCode, string country, string addressName)
    {
        Street=street;
        City = city;
        State=state;
        PostalCode=postalCode;
        Country=country;
        AddressName=addressName;
    }

    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string AddressName { get; set; }

    public class Handler : IRequestHandler<AddAddressCommand, AddressAggregate>
    {
        private IMediator _mediator;
        private readonly IShopAppDbContext _dbContext;

        public Handler(IShopAppDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<AddressAggregate> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.AddressName))
            {
                throw new Exception("NAME_CANNOT_BE_EMPTY");
            }

            var address = AddressAggregate.Create(request.AddressName, request.City, request.Country, request.State,request.Street,request.PostalCode);
            await _dbContext.Address.AddAsync(address, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return address;
        }
    }
}

