using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class OrdersGreaterThanValidator : AbstractValidator<Orders>
    {
        public OrdersGreaterThanValidator( )
        {
            RuleFor(x => x.Menus.date).GreaterThan(DateTime.Now).WithMessage("La fecha debe ser antes de 24hs");

        }
    }
}


