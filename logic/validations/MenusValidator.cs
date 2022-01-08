using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class MenusValidator : AbstractValidator<Menus>
    {
        public MenusValidator( )
        {
            RuleFor(x => x.idMeal).NotEmpty().WithMessage("El campo comida no puede estar vacio");
            RuleFor(x => x.state).NotEmpty().WithMessage("El campo state no puede estar vacio");
            RuleFor(x => x.date).NotEmpty().WithMessage("El campo fecha no puede estar vacio");
            RuleFor(x => x.date).GreaterThan(DateTime.Now).WithMessage("El menu debe cargarse con un minimo de 24hs");
        }
    }
}


