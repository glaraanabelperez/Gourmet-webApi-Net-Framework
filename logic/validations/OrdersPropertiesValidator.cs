using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class OrdersPropertiesValidator : AbstractValidator<Orders>
    {
        public OrdersPropertiesValidator( )
        {
            RuleFor(x => x.idMenu).NotEmpty().WithMessage("El campo menu no puede estar vacio");
            RuleFor(x => x.idUser).NotEmpty().WithMessage("El campo user no puede estar vacio");
            RuleFor(x => x.deliveryAddress).NotEmpty().WithMessage("El direccion fecha no puede estar vacio");
            RuleFor(x => x.amount).NotEmpty().WithMessage("El campo cantidad no puede estar vacio");

        }
    }
}


