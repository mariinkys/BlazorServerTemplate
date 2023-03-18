using Application.Shared.Features.Role.Commands;
using FluentValidation;

namespace Application.Shared.Validators.Role
{
    public class RoleValidator : AbstractValidator<RoleEditCommand>
    {
        public RoleValidator()
        {
            Rules();
        }
        private void Rules()
        {
            //RuleFor(e => e.Id).NotNull().NotEmpty().WithMessage("No puede estar vacío");
        }

    }
}
