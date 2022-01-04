using Domain;
using FluentValidation;


namespace logic.validations
{
    class MenusValidator : AbstractValidator<Menus>
    {
        public MenusValidator()
        {
            RuleFor(x => x.idMeal).NotEmpty().WithMessage("El nombre de la compania no puede estar vacio");
        }
    }
}


