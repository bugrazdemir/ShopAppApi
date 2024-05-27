using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Validator
{
    public  class AddAddressCommandValidator:AbstractValidator<AddAddressCommand>
    {
        public AddAddressCommandValidator() 
        {
            RuleFor(a => a.AddressName).NotEmpty()
                .WithMessage("Lütfen adres ismini giriniz.")
                .NotNull()
                .MaximumLength(50).WithMessage("Adres ismi maksimum 50 karakter olabilir.")
                .MinimumLength(3).WithMessage("Adres ismi minimum 50 karakter olabilir.");

            RuleFor(a => a.Address).NotEmpty()
                .WithMessage("Lütfen adres giriniz.")
                .NotNull()
                .MaximumLength(250).WithMessage("Adres maksimum 250 karakter olabilir.")
                .MinimumLength(10).WithMessage("Adres minimum 10 karakter olabilir.");

        }
    }
}
