using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1[controller]")]
    public class ControllerLibro : ControllerBase
    {
        private readonly ILibroService _libroService;
        public ControllerLibro(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost]
        [Route("list/nome")]
        public IActionResult GetLibriNome(RequestGetLibro request)
        {
            int totalNum = 0;
            var libri = _libroService.GetLibriNome(request.Page * request.PageSize, request.PageSize, request.Cerca, out totalNum);
            var response = new ResponseGetLibro();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.nPagine = (int) Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.DtosLibro(s)).ToList();
            return Ok(FactoryResponse.WhithSucces(response));
        }


        [HttpPost]
        [Route("list/autore")]
        public IActionResult GetLibriAutore(RequestGetLibro request) 
        {
            int totalNum = 0;
            var libri = _libroService.GetLibriAutore(request.Page * request.PageSize, request.PageSize, request.Cerca, out totalNum);
            var response = new ResponseGetLibro();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.nPagine = (int)Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.DtosLibro(s)).ToList();
            return Ok(FactoryResponse.WhithSucces(response));
        }


        [HttpPost]
        [Route("list/categoria")]
        public IActionResult GetLibriCategoria(RequestGetLibro request)
        {
            int totalNum = 0;
            var libri = _libroService.GetLibriCategoria(request.Page * request.PageSize, request.PageSize, request.Cerca, out totalNum);
            var response = new ResponseGetLibro();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.nPagine = (int)Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.DtosLibro(s)).ToList();
            return Ok(FactoryResponse.WhithSucces(response));
        }


        [HttpPost]
        [Route("list/datadipubblicazione")]
        public IActionResult GetLibriDataDiPubblicazione(RequestGetLibro request) 
        { 
            int totalNum = 0;
            var libri = _libroService.GetLibriDataDiPubblicazione(request.Page * request.PageSize, request.PageSize, request.Cerca, out totalNum);
            var response = new ResponseGetLibro();
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.nPagine = (int)Math.Ceiling(pageFounded);
            response.Libri = libri.Select(s => new Application.Models.Dtos.DtosLibro(s)).ToList();
            return Ok(FactoryResponse.WhithSucces(response));
        }


        [HttpPost]
        [Route("new")]
        public IActionResult AggiungiLibro(RequestCreateLibro request)
        {
            var libro = request.ToEntity();
            if(_libroService.ValidateCategoria(libro) == false)
            {
                throw new Exception("categoria inesistente");

            }
            _libroService.AddLibro(libro);
            var response = new ResponseCreateLibro();
            response.Libro = new Application.Models.Dtos.DtosLibro(libro);
            return Ok(FactoryResponse.WhithSucces(response));
        }



        [HttpPost]
        [Route("delete")]
        public IActionResult RimuoviLibro(RequestDeleteLibro request) 
        { 
            var libro = request.ToEntity();
            _libroService.RemoveLibro(libro);
            var response = new ResponseDeleteLibro();
            response.Libro = new Application.Models.Dtos.DtosLibro(libro);
            return Ok(FactoryResponse.WhithSucces(response));
        }



        [HttpPost]
        [Route("edit")]
        public IActionResult ModificaLibro(RequestEditLibro request) 
        {
            var libro = request.ToEntity();
            _libroService.UpdateLibro(libro);
            var response = new ResponseEditLibro();
            response.Libro = new Application.Models.Dtos.DtosLibro(libro);
            return Ok(FactoryResponse.WhithSucces(response));
        }
    }
}
