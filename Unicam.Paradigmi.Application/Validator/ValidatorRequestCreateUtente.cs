using FluentValidation;
using Unicam.Paradigmi.Application.Extension;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatorRequestCreateUtente : AbstractValidator<RequestCreateUtente>
    {
        public ValidatorRequestCreateUtente() 
        {
            RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome non può essere vuoto")
            .NotNull()
            .WithMessage("Nome non può essere nullo")
            .MinimumLength(3)
            .WithMessage("Nome deve essere lungo almeno 3 caratteri");

            RuleFor(x => x.Cognome)
            .NotEmpty()
            .WithMessage("Cognome non può essere vuoto")
            .NotNull()
            .WithMessage("Cognome non può essere nullo")
            .MinimumLength(3)
            .WithMessage("Cognome deve essere lungo almeno 3 caratteri");

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email non può essere vuota")
            .NotNull()
            .WithMessage("Email non può essere nulla")
            .MinimumLength(3)
            .WithMessage("Email deve essere lunga almeno 3 caratteri");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password non può essere vuota")
            .NotNull()
            .WithMessage("Password non può essere nulla")
            .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$", "Attenzione: La password deve rispettare i seguenti requisiti di sicurezza:\r\n- Deve contenere almeno 6 caratteri.\r\n- Deve includere almeno una lettera maiuscola.\r\n- Deve contenere almeno un numero.\r\n- Deve includere almeno un carattere speciale (ad esempio: !, @, #, $, %, ^, &, *).");
        }
    }
}
