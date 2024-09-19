using Castle.Core.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Modelli.Entities;
using Unicam.Paradigmi.Modelli.Repositories;

namespace Unicam.Paradigmi.Application.Services
{
    public class UtenteServie : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        private readonly OptionJwtAutentication _optionJwtAutentication;

        public UtenteServie(UtenteRepository utenteRepository, IOptions<OptionJwtAutentication> jwtOption)
        {
            _utenteRepository = utenteRepository;
            _optionJwtAutentication = jwtOption.Value;
        }

        public void AddUtente(Utente utente)
        {
            _utenteRepository.Add(utente);
            _utenteRepository.Save();
        }

        public bool VerifyEmail(Utente utente)
        {
            if (_utenteRepository.ControlloEmail(utente).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }

        public bool VerifyUtente(Utente utente)
        {
            if (_utenteRepository.ControlloUtente(utente).IsNullOrEmpty())
            {
                return false;
            }
            return true;
        }


        public string CreateToken(Utente utente)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, utente.Email),
                new Claim("Id", utente.IdUtente.ToString())
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_optionJwtAutentication.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(_optionJwtAutentication.Issuer, null, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }


    }
}
