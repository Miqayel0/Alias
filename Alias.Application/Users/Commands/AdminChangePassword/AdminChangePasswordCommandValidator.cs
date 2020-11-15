using FluentValidation;

namespace Alias.Application.Users.Commands.ChangePassword
{
    public class AdminChangePasswordCommandValidator : AbstractValidator<AdminChangePasswordCommand>
    {
        public AdminChangePasswordCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.NewPassword).NotEmpty();
        }
    }
}
