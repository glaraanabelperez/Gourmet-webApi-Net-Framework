using System;
using Domain;
using Domain.States;
using FluentValidation;

namespace logic.validations
{
    class MealsValidator : AbstractValidator<MealsDto>
    {
        public MealsValidator( )
        {
            RuleFor(x => x.type).NotEmpty().WithMessage("El campo typo no puede estar vacio");
            RuleFor(x => x.title).NotEmpty().WithMessage("El campo title no puede estar vacio");
            RuleFor(x => x.description).NotEmpty().WithMessage("El campo descripcion no puede estar vacio");
        }
    }
}


