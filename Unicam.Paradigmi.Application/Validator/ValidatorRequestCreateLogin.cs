using FluentValidation;
using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Validator
{
    public class ValidatorRequestCreateLogin : AbstractValidator<RequestCreateLogin>
    {
        public ValidatorRequestCreateLogin() 
        {
            RuleFor(v => v.Username)
                .NotEmpty()
                .WithMessage("Username non può essere vuoto")
                .NotNull()
                .WithMessage("Username non può essere nullo");

            RuleFor(v => v.Password)
                .NotEmpty()
                .WithMessage("Password non può essere vuota")
                .NotNull()
                .WithMessage("Password non può essere nulla");
        }
    }
}
