using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatorRequestDeleteLibro : AbstractValidator<RequestDeleteLibro>
    {
        public ValidatorRequestDeleteLibro() 
        {
            RuleFor(v => v.ISBN)
            .NotEmpty()
            .WithMessage("ISBN non può essere vuoto")
            .NotNull()
            .WithMessage("ISBN non può essere nullo")
            .MinimumLength(3)
            .WithMessage("ISBN deve avere almeno 3 caratteri");
        }
    }
}
