using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WH.Application.UseCases.Users.Queries.LoginQuery
{
    public class LoginValidator : AbstractValidator<LoginQuery>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Username es requerido")
                .EmailAddress().WithMessage("Username debe ser un correo electrónico válido");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password es requerido");
        }
    }
}
