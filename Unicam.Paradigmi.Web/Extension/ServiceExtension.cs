﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Unicam.Paradigmi.Application.Options;
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

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization", Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
                });
                
            });

            services.AddFluentValidationAutoValidation();

            var jwtAuthenticationOption = new OptionJwtAutentication();
            config.GetSection("JwtAuthentication").Bind(jwtAuthenticationOption);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                .AddJwtBearer(options =>
                {
                    string key = "UnicamParadigmi.Chiave1234567890123";
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens
                    .TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://paradigmi.unicam.it",
                        IssuerSigningKey = securityKey
                    };
                });

            services.AddOptions(config);

            return services;
        }
        private static IServiceCollection AddOptions(this IServiceCollection services,
            IConfiguration config)
        {
            services.Configure<OptionJwtAutentication>(config.
                GetSection("jwtAuthentication")
                );


            return services;
        }

    }
}
