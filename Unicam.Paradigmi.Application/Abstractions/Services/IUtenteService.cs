using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        void AddUtente(Utente utente);
        bool VerifyUtente(Utente utente);
        bool VerifyEmail(Utente utente);
    }
}
