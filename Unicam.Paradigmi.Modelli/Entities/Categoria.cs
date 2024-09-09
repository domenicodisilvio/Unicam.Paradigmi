using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Modelli.Entities
{
    public class Categoria{
        public string Nome { get; set; }
        public ICollection<Libro> Libri { get; set; }
    }
}
