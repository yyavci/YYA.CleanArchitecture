using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYA.OnionArchitecture.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidation()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(128);
        }
    }
}
