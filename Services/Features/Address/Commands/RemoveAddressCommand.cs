using MediatR;
using Application.Common.Interfaces;

namespace Application.Features.Address.Commands;

public class RemoveAddressCommand:IRequest
{
    public RemoveAddressCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }

    public class Handler:IRequestHandler<RemoveAddressCommand>
    {
        private readonly IShopAppDbContext _dbContext;
        public Handler(IShopAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _dbContext.Address.FindAsync(request.Id);
            if (address is null) 
            {
                throw new Exception("Adres bulunamadı.");
            }
            _dbContext.Address.Remove(address);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

