using Application.Features.Address.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Validators;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand> 
{
    public AddUserCommandValidator()
    {
        RuleFor(u => u.Name).NotEmpty()
            .WithMessage("Lütfen kullanıcı ismi giriniz")
            .NotNull()
            .MaximumLength(50).WithMessage("İsminiz maksimum 50 karakter olabilir.")
            .MinimumLength(3).WithMessage("İsminiz minimum 3 karakter olabilir");

        RuleFor(u => u.LastName).NotEmpty()
            .WithMessage("Lütfen kullanıcı soy ismi giriniz")
            .NotNull()
            .MaximumLength(50).WithMessage("Soy isminiz maksimum 50 karakter olabilir.")
            .MinimumLength(3).WithMessage("Soy isminiz minimum 3 karakter olabilir");

        RuleFor(u => u.Email).NotEmpty()
            .WithMessage("Lütfen email giriniz")
            .NotNull()
            .MaximumLength(50).WithMessage("Email maksimum 50 karakter olabilir.")
            .MinimumLength(11).WithMessage("Email minimum 11 karakter olabilir");

        RuleFor(u => u.Phone).NotEmpty()
            .WithMessage("Lütfen telefon numaranızı giriniz")
            .NotNull()
            .Length(13).WithMessage("Telefon numaranız  13 karakter olmalıdır.");
            
    }

}
