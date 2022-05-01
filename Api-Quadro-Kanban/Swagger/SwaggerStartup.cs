using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NSwag;
using NJsonSchema.Generation;
using System.Text;

namespace Api_Quadro_Kanban.Swagger
{
    public class SwaggerStartup
    {
        private static readonly string title = "Quadro Kanban - API";

        public static void ConfigureToken(IServiceCollection services, IConfiguration configuration)
        {

            var key = Encoding.ASCII.GetBytes("App-Teste-Pedro-Bruno");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void ServicoSwagger(IServiceCollection services)
        {

            services.AddApiVersioning(config =>
            {
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "VVV";
                options.SubstituteApiVersionInUrl = true;
            })
            .AddSwaggerDocument(document =>
            {
                document.AddSecurity("JWT", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Scheme = "Bearer",
                    Description = "Digite Bearer + Token"
                });

                document.DocumentName = "v1";
                document.ApiGroupNames = new[] { "1" };
                document.DefaultDictionaryValueReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                document.PostProcess = d =>
                {
                    d.Info.Title = title;
                    d.Info.Description = "Versão 1.0";

                };
            });
        }

        public static void AplicacaoSwagger(IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
