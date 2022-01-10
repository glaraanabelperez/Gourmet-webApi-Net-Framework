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
            RuleFor(x => x.idMeal).NotEmpty().WithMessage("El campo comida no puede estar vacio");
            RuleFor(x => x.state).NotEmpty().WithMessage("El campo state no puede estar vacio");
            RuleFor(x => x.date).NotEmpty().WithMessage("El campo fecha no puede estar vacio");
        }
    }
}


