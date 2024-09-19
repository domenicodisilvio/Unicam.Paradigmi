using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Factories;
using Unicam.Paradigmi.Application.Models.Requests;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ControllerUtente : ControllerBase
    {
        private readonly IUtenteService _serviceUtente;

        public ControllerUtente(IUtenteService serviceUtente)
        {
            _serviceUtente = serviceUtente;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult NuovoUtente(RequestCreateUtente request)
        {
            var utente = request.ToEntity();
            if(_serviceUtente.VerifyEmail(utente) == true)
            {
                throw new Exception("Email già presente");
            }
            _serviceUtente.AddUtente(utente);
            var response = new ResponseCreateUtente();
            response.Utente = new Application.Models.Dtos.DtosUtente(utente);
            return Ok(FactoryResponse.WhithSucces(response));
        }



        [HttpPost]
        [Route("login")]
        public IActionResult Login(RequestCreateLogin request)
        {
            var utente = request.ToEntity();
            if (_serviceUtente.VerifyUtente(utente) == false)
            {
                throw new Exception("Email o password errati");
            }
            string token = _serviceUtente.CreateToken(utente);
            return Ok(FactoryResponse.WhithSucces(new ResponseCreateLogin(token)));
        }
    }
}
