using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class DtosLibro
    {
        public string ISBN { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;

        public string Autore {  get; set; } = string.Empty;

        public DateTime DataDiPubblicazione { get; set; }

        public string Editore { get; set; } = string.Empty;

        public string nomeCategoria { get;  set; } = string.Empty;

        public DtosLibro() { }

        public DtosLibro(Libro libro)
        {
            ISBN = libro.ISBN;
            Nome = libro.Nome;
            Autore = libro.Autore;
            DataDiPubblicazione = libro.DataDiPubblicazione;
            Editore = libro.Editore;
            nomeCategoria = libro.nomeCategoria;
        }
    }
}
