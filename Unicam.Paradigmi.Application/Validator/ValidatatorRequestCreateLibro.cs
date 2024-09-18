using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatatorRequestCreateLibro : AbstractValidator<RequestCreateLibro>
    {
        public ValidatatorRequestCreateLibro() 
        {
            RuleFor(v => v.Editore)
            .NotEmpty()
            .WithMessage("Editore non può essere vuoto")
            .NotNull()
            .WithMessage("Editore non può essere nullo")
            .MinimumLength(3)
            .WithMessage("Il campo Editore deve avere almeno 3 caratteri");

            RuleFor(v => v.Autore)
            .NotEmpty()
            .WithMessage("Autore non può essere vuoto")
            .NotNull()
            .WithMessage("Autore non può essere nullo")
            .MinimumLength(3)
            .WithMessage("Autore deve avere almeno 3 caratteri");


            RuleFor(v => v.Nome)
            .NotEmpty()
            .WithMessage("Nome non può essere vuoto")
            .NotNull()
            .WithMessage("Nome non può essere nullo")
            .MinimumLength(3)
            .WithMessage("Nome deve avere almeno 3 caratteri");


            RuleFor(v => v.nomeCategoria)
            .NotEmpty()
            .WithMessage("Categoria non può essere vuota")
            .NotNull()
            .WithMessage("Categoria non può essere nullo")
            .MinimumLength(3)
            .WithMessage("Categoria deve avere almeno 3 cartteri");

            RuleFor(v => v.DataDiPubblicazione)
            .NotEmpty()
            .WithMessage("Data Di Pubblicazione non può essere vuoto")
            .NotNull()
            .WithMessage("Data di Pubblicazione non può essere nullo");


            RuleFor(v => v.ISBN)
            .NotEmpty()
            .WithMessage("ISBN non può essere vuoto")
            .NotNull()
            .WithMessage("ISBN non può essere nullo")
            .MinimumLength(3)
            .WithMessage("Il campo ISBN deve avere almeno 3 caratteri");
        }
    }
}
