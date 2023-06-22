﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.OnionArchitecture.Application.Settings.Authentication
{
    public class JwtSettings : ISettings
    {

        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationDay { get; set; }
    }
}
