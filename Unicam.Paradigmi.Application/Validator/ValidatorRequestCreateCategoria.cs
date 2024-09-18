using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatorRequestCreateCategoria : AbstractValidator<RequestCreateCategoria>
    {
        public ValidatorRequestCreateCategoria()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("Nome non può essere nullo")
                .NotEmpty()
                .WithMessage("Nome non può essere vuoto")
                .MinimumLength(3)
                .WithMessage("Nome deve essere lungo almeno 3 caratteri");
        }
    }
}
