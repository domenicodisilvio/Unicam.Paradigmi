namespace Unicam.Paradigmi.Application.Models.Requests
{
    public class RequestGetLibro
    {
        public int PageSize { get; set; }

        public int Page {  get; set; }

        public string? Cerca {  get; set; }
    }
}
