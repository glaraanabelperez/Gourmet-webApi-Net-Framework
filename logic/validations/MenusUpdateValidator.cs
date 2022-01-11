using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class MenusUpdateValidator : AbstractValidator<MenusDto>
    {
        public MenusUpdateValidator( )
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("El campo id no puede estar vacio");
            RuleFor(x => x.state).NotEmpty().WithMessage("El campo state no puede estar vacio");
        }
    }
}


