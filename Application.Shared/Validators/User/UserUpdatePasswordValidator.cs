using Application.Shared.Features.User.Commands;
using FluentValidation;

namespace Application.Shared.Validators.User
{
    public class UserUpdatePasswordValidator : AbstractValidator<UserUpdatePasswordCommand>
    {
        public UserUpdatePasswordValidator()
        {
            Rules();
        }
        private void Rules()
        {
            RuleFor(e => e.OldPassword).NotNull().NotEmpty().WithMessage("No puede estar vacío");
            RuleFor(e => e.NewPassword).NotNull().NotEmpty().WithMessage("No puede estar vacío");
        }

    }
}
