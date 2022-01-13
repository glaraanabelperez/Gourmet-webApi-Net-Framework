using System;
using Domain;
using Domain.States;
using FluentValidation;

namespace logic.validations
{
    class UsersValidator : AbstractValidator<UsersDto>
    {
        public UsersValidator( )
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("El campo email no puede estar vacio");
            RuleFor(x => x.pass).NotEmpty().WithMessage("El campo pass no puede estar vacio");
            RuleFor(x => x.name).NotEmpty().WithMessage("El campo name no puede estar vacio");
            RuleFor(x => x.lastName).NotEmpty().WithMessage("El lastName typo no puede estar vacio");
            RuleFor(x => x.phone).NotEmpty().WithMessage("El campo phone no puede estar vacio");
            RuleFor(x => x.direction).NotEmpty().WithMessage("El direccion descripcion no puede estar vacio");
            RuleFor(x => x.state).NotEmpty().WithMessage("El campo state no puede estar vacio");
        }
    }
}


