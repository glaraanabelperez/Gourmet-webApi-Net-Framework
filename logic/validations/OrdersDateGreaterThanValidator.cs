using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class OrdersGreaterThanValidator : AbstractValidator<DateTime>
    {
        public OrdersGreaterThanValidator( )
        {
            RuleFor(x => x).GreaterThan(DateTime.Now).WithMessage("La fecha debe ser con 24 hs de anticipacion");

        }
    }
}


