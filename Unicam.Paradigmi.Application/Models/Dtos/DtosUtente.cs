﻿using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class DtosUtente
    {
        public int IdUtente { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


        public DtosUtente(Utente utente)
        {
            IdUtente = utente.IdUtente;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            Email = utente.Email;
            Password = utente.Password;
        }
    }
}
