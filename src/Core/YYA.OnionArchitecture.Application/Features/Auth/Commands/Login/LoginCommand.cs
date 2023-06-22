﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Wrappers;

namespace YYA.OnionArchitecture.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<ServiceResponse<LoginDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
