using MediatR;
using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands;

public class UpdateAddressCommand:IRequest
{
    public UpdateAddressCommand(int id , string address,string addressName)
    {
        Id = id;
        Address=address;
        AddressName = addressName;
    }
    public int Id { get; set; }
    public string Address { get; set; }
    public string AddressName { get; set; }

    public class Handler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IShopAppDbContext _dbContext;
        public Handler(IShopAppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task Handle(UpdateAddressCommand request,CancellationToken cancellationToken)
        {
            var address = await _dbContext.Address.FindAsync(request.Id);
            if (address is null) 
            { 
                throw new Exception("Adres bulunamadı."); 
            }
            address.Update(request.Address,request.AddressName);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
