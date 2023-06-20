using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YYA.OnionArchitecture.Application.Wrappers;

namespace YYA.OnionArchitecture.Application.Extensions
{
    public static class ValidationResultExtension
    {
        public static string ValidationErrors(this ValidationResult validationResult)
        {
            if (validationResult == null)
                return string.Empty;

            if (validationResult.IsValid)
                return string.Empty;

            return string.Join("/n", validationResult.Errors.Select(f => f.ErrorMessage));
        }

    }
}
