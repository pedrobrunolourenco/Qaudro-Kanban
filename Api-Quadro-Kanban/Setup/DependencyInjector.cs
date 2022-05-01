using Kanban.Application.Interfaces;
using Kanban.Application.Services;
using Kanban.Domain.Intefaces;
using Kanban.Domain.Services;
using Kanban.Infa.Data.Contextos;
using Kanban.Infa.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api_Quadro_Kanban.Setup
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddScoped<IRepositoryQuadro, RepositoryQuadro>();
            services.AddScoped<IServiceQuadro, ServiceQuadro>();
            services.AddScoped<IAppQuadro, AppQuadro>();
            services.AddScoped<ContextEF>();

        }
    }
}
