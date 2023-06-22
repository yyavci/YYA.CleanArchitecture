using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.OnionArchitecture.Application.Features.Auth.Commands.Login
{
    public class LoginValidation : AbstractValidator<LoginCommand>
    {
        public LoginValidation()
        {
            RuleFor(f => f.Email).NotEmpty().EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("auth.login.email.notvalid");
            RuleFor(f => f.Password).NotEmpty().WithMessage("auth.login.password.notempty");
        }
    }
}
