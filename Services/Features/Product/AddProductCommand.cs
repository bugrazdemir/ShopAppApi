using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Application.Common.Interfaces;

namespace Application.Features.Product
{
    public class AddProductCommand : IRequest<ProductAggregate>
    {
        public AddProductCommand(string productName, string description, decimal price, decimal quantity)
        {
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            ProductUploadDate = DateTime.Now;
        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ProductUploadDate { get; set; }

        public class Handler : IRequestHandler<AddProductCommand, ProductAggregate>
        {
            private IMediator _mediator;
            private readonly IShopAppDbContext _dbContext;

            public Handler(IShopAppDbContext dbContext, IMediator mediator)
            {
                _dbContext = dbContext;
                _mediator = mediator;
            }

            public async Task<ProductAggregate> Handle(AddProductCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrEmpty(request.ProductName))
                {
                    throw new Exception("PRODUCT_NAME_CANNOT_BE_EMPTY");
                }

                var product = ProductAggregate.Create(request.ProductName, request.Description, request.Price, request.Quantity);
                await _dbContext.Products.AddAsync(product, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return product;
            }
        }
    }
}