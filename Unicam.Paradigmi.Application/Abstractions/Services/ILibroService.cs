using Unicam.Paradigmi.Modelli.Entities;
namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface ILibroService
    {
        List<Libro> GetLibri();
        List<Libro> GetLibriNome(int from, int num, string? name, out int totalNum);

        List<Libro> GetLibriAutore(int from, int num, string? autore, out int totalNum);

        List<Libro> GetLibriCategoria(int form, int num, string? categoria, out int totalNum);

        List<Libro> GetLibriDataDiPubblicazione(int from, int num, string? dataDiPubblicazione, out int totalNum);

        void AddLibro(Libro libro);
        void RemoveLibro(Libro libro);
        void UpdateLibro(Libro libro);
        bool ValidateCategoria(Libro libro);
    }
}
