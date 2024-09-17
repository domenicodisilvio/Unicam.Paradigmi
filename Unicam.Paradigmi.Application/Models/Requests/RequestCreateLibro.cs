using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class RequestCreateLibro
    {
        public string ISBN { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Autore { get; set; } = string.Empty;

        public string Editore { get; set; } = string.Empty;

        public string nomeCategoria { get; set; } = string.Empty;

        public string DataDiPubblicazione {  get; set; } = string.Empty;

        public Libro ToEntity()
        {
            var libro = new Libro();
            libro.ISBN = ISBN;  
            libro.Nome = Nome;
            libro.Autore = Autore;
            libro.Editore = Editore;
            libro.nomeCategoria = nomeCategoria;
            libro.DataDiPubblicazione = DateTime.Parse(DataDiPubblicazione);
            return libro;
        }


    }
}
