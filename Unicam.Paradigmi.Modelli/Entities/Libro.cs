using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Paradigmi.Modelli.Entities
{
    public class Libro{
        public string ISBN { get; set; }    
        public string Nome { get; set; }
        public string Autore { get; set; }
        public DateTime DataDiPubblicazione { get; set; }
        public string Editore { get; set; }
        public Categoria Categoria { get; set; }
        public string nomeCategoria { get; set; }
    }
}
