using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class OrdersDateLessThanValidator : AbstractValidator<DateTime>
    {
        public OrdersDateLessThanValidator( )
        {
            RuleFor(x => x).LessThan(DateTime.Now).WithMessage("La fecha debe ser luego de las 24hs de la fecha de entrega");

        }
    }
}


