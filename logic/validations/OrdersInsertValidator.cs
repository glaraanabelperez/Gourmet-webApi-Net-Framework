using System;
using Domain;
using FluentValidation;


namespace logic.validations
{
    class OrdersInsertValidator : AbstractValidator<OrdersDto>
    {
        public OrdersInsertValidator( )
        {
            RuleFor(x => x.idMenu).NotEmpty().WithMessage("El campo menu no puede estar vacio");
            RuleFor(x => x.idUser).NotEmpty().WithMessage("El campo user no puede estar vacio");
            RuleFor(x => x.state).NotEmpty().WithMessage("El campo estado no puede estar vacio");
            RuleFor(x => x.state).NotEqual("activo").WithMessage("El estado dle meu es suspendido o eliminado");
            RuleFor(x => x.amount).NotEmpty().WithMessage("El campo cantidad no puede estar vacio");
            RuleFor(x => x.deliveryAddress).NotEmpty().WithMessage("El direccion fecha no puede estar vacio");
            RuleFor(x => x.MenusDto).NotEmpty().WithMessage("Los Datos del menu no pueden estar vacios");
        }
    }
}


