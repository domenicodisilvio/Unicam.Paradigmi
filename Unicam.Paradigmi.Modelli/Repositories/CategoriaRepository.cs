using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Context;
using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Modelli.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public MyDbContext Context { get; set; }
        public CategoriaRepository(MyDbContext ctx) : base(ctx) { }
        public List<Categoria> ControlloCategoria(Categoria categoria)
        {
            var query = _ctx.Categorie.AsQueryable();
            query = query.Where(o => o.Nome.Equals(categoria.Nome));
            return query.ToList();
        }
        public List<Libro> ControlloEliminazione(Categoria categoria)
        {
            var query = _ctx.Libri.AsQueryable();
            query = query.Where(o => o.nomeCategoria.Equals(categoria.Nome));
            return query.ToList();
        }
    }
}
