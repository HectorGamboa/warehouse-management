using FluentValidation;
using WH.Application.UseCases.Users.Queries.LoginQuery;

namespace WH.Application.UseCases.Users.Commands.RevokeRefreshTokenCommand
{
    public class RevokeRefreshTokenValidator : AbstractValidator<RevokeRefreshTokenCommand>
    {
        public RevokeRefreshTokenValidator()
        {
            RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage("TokenRefresh required");
        }
    }
}
