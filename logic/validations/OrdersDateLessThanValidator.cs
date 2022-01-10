using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class OrdersDateLessThanValidator : AbstractValidator<Orders>
    {
        public OrdersDateLessThanValidator( )
        {
            RuleFor(x => x.Menus.date).LessThan(DateTime.Now).WithMessage("La fecha debe ser luego de 24hs d ela fecha de entrega");

        }
    }
}


