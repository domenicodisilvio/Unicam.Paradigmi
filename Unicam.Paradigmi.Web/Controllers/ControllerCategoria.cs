using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ControllerCategoria : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public ControllerCategoria(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult AggiungiCategoria(RequestCreateCategoria request)
        {
            var categoria = request.ToEntity();
            if (_categoriaService.ValidateCategoria(categoria) == false)
            {
                throw new Exception("Categoria non valida");
            }
            _categoriaService.AddCategoria(categoria);
            var response = new ResponseCreateCategoria();
            response.Categoria = new Application.Models.Dtos.DtosCategoria(categoria);
            return Ok(FactoryResponse.WhithSucces(response));
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult RimuoviCategoria(RequestDeleteCategoria request)
        {
            var categoria = request.ToEntity();
            if (_categoriaService.ValidateCategoria(categoria) == true)
            {
                throw new Exception("Categoria non valida");
            }
            if (_categoriaService.ValidateEliminazione(categoria) == false)
            {
                throw new Exception("La categoria contiene dei libri");
            }
            _categoriaService.DeleteCategoria(categoria);
            var response = new ResponseDeleteCategoria();
            response.Categoria = new Application.Models.Dtos.DtosCategoria(categoria);
            return Ok(FactoryResponse.WhithSucces(response));
        }

    }
}
