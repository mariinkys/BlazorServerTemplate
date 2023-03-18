using Application.Shared.Features.User.Commands;
using FluentValidation;

namespace Application.Shared.Validators.User
{
    public class UserValidator : AbstractValidator<UserEditCommand>
    {
        public UserValidator()
        {
            Rules();
        }
        private void Rules()
        {
            RuleFor(e => e.UserName).NotNull().NotEmpty().WithMessage("No puede estar vacío");
            RuleFor(e => e.Password).NotNull().NotEmpty().WithMessage("No puede estar vacío");
        }

    }
}
