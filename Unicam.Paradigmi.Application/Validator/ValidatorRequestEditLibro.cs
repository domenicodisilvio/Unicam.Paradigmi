using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatorRequestEditLibro : AbstractValidator<RequestEditLibro>
    {
        public ValidatorRequestEditLibro() 
        {
            RuleFor(v => v.Editore)
                .NotEmpty()
                .WithMessage("Editore non può essere vuoto")
                .NotNull()
                .WithMessage("Editore non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Editore deve avere almeno 3 caratteri");

            RuleFor(v => v.Autore)
                .NotEmpty()
                .WithMessage("Autore non può essere vuoto")
                .NotNull()
                .WithMessage("Autore non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Autore deve essere lungo almeno 3 caratteri");

            RuleFor(v => v.Nome)
                .NotEmpty()
                .WithMessage("Nome non può essere vuoto")
                .NotNull()
                .WithMessage("Nome non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Nome deve avere almeno 3 caratteri");

            RuleFor(v => v.ISBN)
                .NotEmpty()
                .WithMessage("ISBN non può essere vuoto")
                .NotNull()
                .WithMessage("ISBN non può essere nullo")
                .MinimumLength(3)
                .WithMessage("ISBN deve contenere almeno 3 caratteri");

            RuleFor(v => v.DataDiPubblicazione)
                .NotEmpty()
                .WithMessage("Data di Pubblicazione non può essere vuota")
                .NotNull()
                .WithMessage("Data di Pubblicazione non può essere nullo");

            RuleFor(v => v.nomeCategoria)
                .NotEmpty()
                .WithMessage("Categoria non può essere vuoto")
                .NotNull()
                .WithMessage("Categoria non può essere nulla")
                .MinimumLength(3)
                .WithMessage("Categoria deve contenere almeno 3 caratteri");




        



        }
    }
}
