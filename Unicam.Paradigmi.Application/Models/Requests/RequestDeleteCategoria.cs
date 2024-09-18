using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class RequestDeleteCategoria
    {
        public string Nome { get; set; }

        public Categoria ToEntity()
        {
            var categoria = new Categoria();
            categoria.Nome = Nome;
            return categoria;
        }
    }
}
