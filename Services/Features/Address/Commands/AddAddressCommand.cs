using Domain.Models;
using Application.Common.Interfaces;
using MediatR;
using System.Numerics;
using System.Xml.Linq;
using Application.Features.Address.Commands.Validator;
namespace Application.Features.Address.Commands;

public class AddAddressCommand : IRequest<AddressAggregate>
{
    public AddAddressCommand(string address, string addressName)
    {
        Address = address;
        AddressName = addressName;
    }

    public string Address { get; set; }
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
            var validator=new AddAddressCommandValidator();
            var validationResult=validator.Validate(request);
            if(validationResult != null)
            {
                if(validationResult.IsValid==false) 
                {
                    throw new Exception("Adres eklerken hata oluştu.");
                }

            }
            var addresses = AddressAggregate.Create(request.AddressName, request.Address);
            await _dbContext.Address.AddAsync(addresses, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return addresses;
        }
    }
}

