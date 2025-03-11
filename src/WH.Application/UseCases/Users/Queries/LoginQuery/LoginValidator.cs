using FluentValidation;

namespace WH.Application.UseCases.Users.Queries.LoginQuery
{
    public class LoginValidator : AbstractValidator<LoginQuery>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email required")
                .EmailAddress().WithMessage("Email invalid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password required");
        }
    }
}
