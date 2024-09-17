using Castle.Core.Internal;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Modelli.Entities;
using Unicam.Paradigmi.Modelli.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _libroRepository;

        public LibroService(LibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public void AddLibro(Libro libro)
        {
            _libroRepository.Add(libro);
            _libroRepository.Save();
        }

        public void RemoveLibro(Libro libro)
        {
            _libroRepository.Delete(libro);
            _libroRepository.Save();
        }

        public void UpdateLibro(Libro libro)
        {
            _libroRepository.Modify(libro);
            _libroRepository.Save();
        }

        public List<Libro> GetLibri()
        {
            return new List<Libro>();
        }


        public List<Libro> GetLibriNome(int from, int num, string? name, out int totalNum)
        {
            return _libroRepository.GetLibriNome(from, num, name, out totalNum);
        }

        public List<Libro> GetLibriAutore(int from, int num, string? autore, out int totalNum)
        {
            return _libroRepository.GetLibriAutore(from, num, autore, out totalNum);
        }

        public List<Libro> GetLibriCategoria(int from, int num, string? categoria, out int totalNum)
        {
            return _libroRepository.GetLibriCategoria(from, num, categoria, out totalNum);
        }

        public List<Libro> GetLibriDataDiPubblicazione(int from, int num, string? dataDiPubblicazione, out int totalNum)
        {
            return _libroRepository.GetLibriDataDiPubblicazione(from, num, DateTime.Parse(dataDiPubblicazione), out totalNum);
        }

        public bool ValidateCategoria(Libro libro)
        {
            if (_libroRepository.ControlloCategoria(libro).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }
    }
}
