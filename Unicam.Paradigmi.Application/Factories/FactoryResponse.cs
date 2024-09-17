using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Application.Factories
{
    public class FactoryResponse
    {
        public static ResponseBase<T> WhithSucces<T>(T result)
        {
            var response = new ResponseBase<T>();
            response.IsSuccess = true;
            response.Result = result;
            return response;
        }

        public static ResponseBase<T> WithError<T>(T result)
        {
            var response = new ResponseBase<T>();
            response.IsSuccess = false;
            response.Result = result;
            return response;
        }

        public static ResponseBase<string?> WithError(Exception exception)
        {
            var response = new ResponseBase<string>();
            response.IsSuccess = false;
            response.Errors = new List<string>();
            {
                exception.Message
            };
            return response;
        }
    }
}
