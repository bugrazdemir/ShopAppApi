/*using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands.Validator
{
    public class CreateOrderCommandValidator:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(o => o.UserAggregate.Name)
                .NotEmpty().WithMessage("Lütfen sepete bir şeyler ekleyin.")
                .MLength(50).WithMessage("")
        }
    }
}
*/