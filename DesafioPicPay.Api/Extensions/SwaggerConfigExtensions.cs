using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;

namespace DesafioPicPay.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerConfigExtensions
    {
        public static void SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Desafio Picpay",
                        Version = "v1",
                        Description = "Transfer Api",
                        Contact = new OpenApiContact
                        {
                            Name = "Carlos Silva",
                            Url = new Uri("https://github.com/Carlinhao")
                        }
                    });

                //c.AddSecurityDefinition(
                //    "Bearer",
                //    new OpenApiSecurityScheme
                //    {
                //        Name = "Authorization",
                //        BearerFormat = "JWT",
                //        Description = "Copy 'Bearer ' + token'",
                //        Scheme = "Authorization",
                //        In = ParameterLocation.Header,
                //        Type = SecuritySchemeType.ApiKey
                //    });

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //          new OpenApiSecurityScheme
                //          {
                //              Reference = new OpenApiReference
                //              {
                //                  Type = ReferenceType.SecurityScheme,
                //                  Id = "Bearer"
                //              }
                //          },
                //         Array.Empty<string>()
                //    }
                //});
            });
        }

        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
