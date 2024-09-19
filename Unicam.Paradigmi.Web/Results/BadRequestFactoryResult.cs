using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Models.Responses;

namespace Unicam.Paradigmi.Web.Results
{
    public class BadRequestFactoryResult : BadRequestObjectResult
    {
        public BadRequestFactoryResult(ActionContext context) : base(new BadResponse())
        {
            var retErrors = new List<string>();
            foreach (var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                for (int i = 0; i < errors.Count; i++)
                {
                    retErrors.Add(errors[i].ErrorMessage);
                }
            }
            var response = (BadResponse)Value;
            response.Errors = retErrors;
        }
    }
}
