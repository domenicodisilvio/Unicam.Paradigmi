using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Models.Dtos
{
    public class DtosCategoria
    {
        public string Nome { get; set; } = string.Empty;

        public DtosCategoria() {}
        public DtosCategoria(Categoria categoria)
        {
            Nome = categoria.Nome;
        }
    }
}
