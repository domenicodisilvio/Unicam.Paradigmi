namespace Unicam.Paradigmi.Application.Models.Responses
{
    public class ResponseCreateLogin
    {


        public string Token { get; set; } = string.Empty;
        public ResponseCreateLogin(string token)
        {
            Token = token;
        }
    }
}
