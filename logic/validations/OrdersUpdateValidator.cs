using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class OrdersUpdateValidator : AbstractValidator<OrdersDto>
    {
        public OrdersUpdateValidator( )
        {
            RuleFor(x => x.deliveryAddress).NotEmpty().WithMessage("El direccion fecha no puede estar vacio");
            RuleFor(x => x.amount).NotEmpty().WithMessage("El campo cantidad no puede estar vacio");
        }
    }
}


