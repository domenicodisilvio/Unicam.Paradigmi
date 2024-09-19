using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class RequestCreateLogin
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public Utente ToEntity()
        {
            var utente = new Utente();
            utente.Email = Username;
            utente.Password = Password;
            return utente;
        }
    }
}
