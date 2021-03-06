using AutoMapper;
using Api_Quadro_Kanban.Setup;
using Api_Quadro_Kanban.Swagger;
using Kanban.Application.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kanban.Infa.Data.Contextos;
using Microsoft.EntityFrameworkCore;
using Kanban.Infra.CrossCutting.Filters;

namespace Api_Quadro_Kanban
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SwaggerStartup.ServicoSwagger(services);
            SwaggerStartup.ConfigureToken(services, Configuration);

            services.AddControllers(options =>
            {
               // options.Filters.Add(new FilterLogAlteracaoExclusao());
            });

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.RegisterServices();
            services.AddDbContext<ContextEF>(opt => opt.UseInMemoryDatabase());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SwaggerStartup.AplicacaoSwagger(app);


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
