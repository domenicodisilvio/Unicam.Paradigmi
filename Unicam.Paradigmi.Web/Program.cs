using Unicam.Paradigmi.Application.Extension;
using Unicam.Paradigmi.Modelli.Extension;
using Unicam.Paradigmi.Web.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration).AddModelServices(builder.Configuration).AddWebServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();