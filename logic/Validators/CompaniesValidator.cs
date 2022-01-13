using System;
using Domain;
using Domain.States;
using FluentValidation;

namespace logic.validations
{
    class CompaniesValidator : AbstractValidator<CompaniesDto>
    {
        public CompaniesValidator( )
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("El campo name no puede estar vacio");
            RuleFor(x => x.direction).NotEmpty().WithMessage("El direction pass no puede estar vacio");
            RuleFor(x => x.phone).NotEmpty().WithMessage("El campo phone no puede estar vacio");
        }
    }
}


