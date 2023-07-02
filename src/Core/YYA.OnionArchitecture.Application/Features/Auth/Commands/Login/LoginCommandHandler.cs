using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Authentication;
using YYA.OnionArchitecture.Application.Extensions;
using YYA.OnionArchitecture.Application.Features.Products.Commands.CreateProduct;
using YYA.OnionArchitecture.Application.Settings.Authentication;
using YYA.OnionArchitecture.Application.Wrappers;

namespace YYA.OnionArchitecture.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResponse<LoginDto>>
    {
        private readonly IValidator<LoginCommand> validator;
        private readonly JwtSettings jwtSettings;

        public LoginCommandHandler(IValidator<LoginCommand> validator, IOptions<JwtSettings> jwtSettings)
        {
            this.validator = validator;
            this.jwtSettings = jwtSettings.Value;

        }

        public async Task<ServiceResponse<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException($"{nameof(request)} cannot be null!");

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult != null && !validationResult.IsValid)
                return new ServiceResponse<LoginDto>().Fail(validationResult.ValidationErrors());

            //TODO validate user&pass from db

            LoginDto response = new LoginDto();
            JwtTokenGenerator tokenGenerator = new JwtTokenGenerator(jwtSettings);

            tokenGenerator.GenerateToken(request.Email!);

            response.Token = tokenGenerator.Token;

            return new ServiceResponse<LoginDto>(response);

        }

    }
}
