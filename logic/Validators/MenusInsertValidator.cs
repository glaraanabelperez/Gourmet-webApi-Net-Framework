using System;
using Domain;
using Domain.States;
using FluentValidation;

namespace logic.validations
{
    class MenusInsertValidator : AbstractValidator<MenusDto>
    {
        public MenusInsertValidator( )
        {
            RuleFor(x => x.idMeal).NotEmpty().WithMessage("El campo comida no puede estar vacio");
            RuleFor(x => x.state).NotEmpty().WithMessage("El campo state no puede estar vacio");
            RuleFor(x => x.state).Must(state => States.statesMenusMeals.Contains(state));
            RuleFor(x => x.date).NotEmpty().WithMessage("El campo fecha no puede estar vacio");
            RuleFor(x => x.date).LessThan(DateTime.Now).WithMessage("El menu debe cargarse con un minimo de 24hs");
        }
    }
}


