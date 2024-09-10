using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Context;
using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Modelli.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx) { }
        public List<Utente> ControlloUtente(Utente utente) 
        {
            var query = _ctx.Utenti.AsQueryable();
            query = query.Where(o => o.Email.Equals(utente.Email) && o.Password.Equals(utente.Password));
            return query.ToList();
        }

        public List<Utente> ControlloEmail(Utente utente)
        {
            var query = _ctx.Utenti.AsQueryable();
            query = query.Where(o => o.Email.Equals(utente.Email));
            return query.ToList();
        }
    }
}
