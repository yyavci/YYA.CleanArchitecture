using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public LoginCommandHandler(IValidator<LoginCommand> validator, IConfiguration configuration)
        {
            this.validator = validator;
            this.configuration = configuration;
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
            JwtTokenGenerator tokenGenerator = new JwtTokenGenerator(GetJwtSettings());

            tokenGenerator.GenerateToken(request.Email);

            response.Token = tokenGenerator.Token;

            return new ServiceResponse<LoginDto>(response);

        }


        private JwtSettings GetJwtSettings()
        {
            JwtSettings settings = new JwtSettings();
            settings.Issuer = configuration.GetValue<string>(JwtTokenGenerator.KEY_JWT_ISSUER);
            settings.Audience = configuration.GetValue<string>(JwtTokenGenerator.KEY_JWT_AUDIENCE);
            settings.ExpirationDay = configuration.GetValue<int>(JwtTokenGenerator.KEY_JWT_EXPIRATION_DAYS);
            settings.SecurityKey = configuration.GetValue<string>(JwtTokenGenerator.KEY_JWT_SECURITY_KEY);

            return settings;
        }

        
    }
}
