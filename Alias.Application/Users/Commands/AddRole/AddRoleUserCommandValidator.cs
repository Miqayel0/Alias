﻿using FluentValidation;

namespace Alias.Application.Users.Commands.AddRole
{
    public class AddRoleUserCommandValidator : AbstractValidator<AddRoleToUserCommand>
    {
        public AddRoleUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Role).NotEmpty();
        }
    }
}
