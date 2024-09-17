using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class RequestDeleteLibro
    {
        public string ISBN { get; set; }

        public Libro ToEntity()
        {
            var libro = new Libro();
            libro.ISBN = ISBN;
            return libro;
        }
    }
}
