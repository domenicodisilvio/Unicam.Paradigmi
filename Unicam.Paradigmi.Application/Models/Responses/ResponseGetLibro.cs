using Unicam.Paradigmi.Application.Models.Dtos;

namespace Unicam.Paradigmi.Application.Models.Responses
{
    public class ResponseGetLibro
    {
        public List<DtosLibro> Libri { get; set; } = new List<DtosLibro>();
        public int nPagine { get; set; }
    }
}
