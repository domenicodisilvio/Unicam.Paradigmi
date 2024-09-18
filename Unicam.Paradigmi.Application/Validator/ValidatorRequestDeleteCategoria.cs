using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatorRequestDeleteCategoria : AbstractValidator<RequestDeleteCategoria>
    {
        public ValidatorRequestDeleteCategoria()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Nome non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Nome deve essere lungo almeno 3 caratteri");
        }
    }
}
