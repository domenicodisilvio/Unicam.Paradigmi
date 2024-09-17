using Unicam.Paradigmi.Modelli.Entities;


namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface ICategoriaService
    {
        void AddCategoria(Categoria categoria);

        void DeleteCategoria(Categoria categoria);

        bool ValidateCategoria(Categoria categoria);

        bool ValidateEliminazione(Categoria categoria);
    }
}
