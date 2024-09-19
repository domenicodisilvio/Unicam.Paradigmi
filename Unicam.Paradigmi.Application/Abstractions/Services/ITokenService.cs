using Unicam.Paradigmi.Application.Models.Requests;

namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface ITokenService
    {
        string createToken(RequestCreateLogin request);
    }
}
