using FluentValidation;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Services;

namespace Unicam.Paradigmi.Application.Extension;

public static class ExtensionService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Paradigmi.Application"));
        services.AddScoped<ILibroService, LibroService>();
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<IUtenteService, UtenteServie>();
        return services;
    }
}
