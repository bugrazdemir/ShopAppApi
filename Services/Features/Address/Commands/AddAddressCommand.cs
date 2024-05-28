using Domain.Models;
using Application.Common.Interfaces;
using MediatR;
using System.Numerics;
using System.Xml.Linq;
using Application.Features.Address.Commands.Validator;
using Microsoft.EntityFrameworkCore;
namespace Application.Features.Address.Commands;

public class AddAddressCommand : IRequest<AddressAggregate>
{
    public AddAddressCommand(int userId,string address, string addressName)
    {
        UserId=userId;
        Address = address;
        AddressName = addressName;
    }
    public int UserId { get; set; }
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
            var user=await _dbContext.Users.FirstOrDefaultAsync(a=>a.Id==request.UserId);

            if (user is null) 
            {
                throw new Exception("Kullanıcı bulunamadı.");      
            }
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

