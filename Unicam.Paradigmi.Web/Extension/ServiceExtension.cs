using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

using Unicam.Paradigmi.Web.Results;

namespace Unicam.Paradigmi.Web.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt =>
                {
                    opt.InvalidModelStateResponseFactory = (context) =>
                    {
                        return new BadRequestFactoryResult(context);
                    };
                });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Unicam Paradigmi Test App",
                    Version = "v1"
                });
            });

            services.AddFluentValidationAutoValidation();

            return services;
        }

    }
}
