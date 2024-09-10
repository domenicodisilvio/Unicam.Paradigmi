using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Context;
using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Modelli.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {
        public MyDbContext Context { get; set; }
        public LibroRepository(MyDbContext ctx) : base(ctx){ }
        public List<Libro> GetLibriNome(int from, int num, string? name, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.Nome.ToLower().Contains(name.ToLower()));
            }
            totalNum = query.Count();
            return query.OrderBy(l => l.Nome).Skip(from).Take(num).ToList();
        }

        public List<Libro> GetLibriAutore(int from, int num, string? author, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();
            if (!string.IsNullOrEmpty(author)) 
            {
                query = query.Where(w => w.Autore.ToLower().Contains(author.ToLower()));
            }

            totalNum= query.Count();

            return query.OrderBy(l => l.Autore).Skip(from).Take(num).ToList();

        }

        public List<Libro> GetLibriCategoria(int from, int num, string? category, out int totalNum) 
        {
            var query = _ctx.Libri.AsQueryable();
            if (!string.IsNullOrEmpty(category)) 
            {
                query = query.Where(w => w.nomeCategoria.ToLower().Contains(category.ToLower()));
            }

            totalNum= query.Count();

            return query.OrderBy(t => t.Categoria).Skip(from).Take(num).ToList();
        }

        public List<Libro> GetLibriDataDiPubblicazione(int from, int num, DateTime? dataDiPubblicazione, out int totalNum)
        {
            var query = _ctx.Libri.AsQueryable();
            if (dataDiPubblicazione.HasValue)
            {
                query = query.Where(o => o.DataDiPubblicazione.Equals(dataDiPubblicazione));
            }
            totalNum= query.Count();
            return query.OrderBy(o => o.DataDiPubblicazione).Skip(from).Take(num).ToList(); 
        }

        public List<Categoria> ControlloCategoria(Libro libro)
        {
            var query = _ctx.Categorie.AsQueryable();
            query = query.Where(o => o.Nome.Equals(libro.nomeCategoria));
            return query.ToList();
        }
    }
}
