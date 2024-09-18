using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatorRequestGetLibro : AbstractValidator<RequestGetLibro>
    {
        public ValidatorRequestGetLibro() 
        {
            RuleFor(v => v.PageSize)
                .NotEmpty()
                .WithMessage("Page Size non può essere vuota")
                .NotNull()
                .WithMessage("Page Size non può essere nullo");

            RuleFor(v => v.Cerca)
                .NotEmpty()
                .WithMessage("Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Nome non può essere nullo");
        }
    }
}
