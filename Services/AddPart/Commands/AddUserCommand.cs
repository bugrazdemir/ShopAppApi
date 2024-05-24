using Domain.Models;
using Application.Common.Interfaces;
using MediatR;
using System.Numerics;
using System.Xml.Linq;
namespace Application.AddPart.Commands;

public class AddUserCommand : IRequest<UserAggregate>
{
    public AddUserCommand(string name, string lastName, string email, string phone)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        CreatedDate = DateTime.Now;
        Phone = phone;
    }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedDate { get; set; }

    public class Handler : IRequestHandler<AddUserCommand, UserAggregate>
    {
        private IMediator _mediator;
        private readonly IShopAppDbContext _dbContext;

        public Handler(IShopAppDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<UserAggregate> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new Exception("NAME_CANNOT_BE_EMPTY");
            }

            var user = UserAggregate.Create(request.Name, request.LastName, request.Email, request.Phone);
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}

