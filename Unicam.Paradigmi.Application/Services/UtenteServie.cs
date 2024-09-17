using Castle.Core.Internal;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Modelli.Entities;
using Unicam.Paradigmi.Modelli.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    public class UtenteServie : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;

        public UtenteServie(UtenteRepository utenteRepository)
        {
            _utenteRepository = utenteRepository;
        }

        public void AddUtente(Utente utente)
        {
            _utenteRepository.Add(utente);
            _utenteRepository.Save();
        }

        public bool VerifyEmail(Utente utente)
        {
            if (_utenteRepository.ControlloEmail(utente).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }

        public bool VerifyUtente(Utente utente)
        {
            if (_utenteRepository.ControlloUtente(utente).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }
    }
}
