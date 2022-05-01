using AutoMapper;
using Kanban.Application.DTOs;
using Kanban.Domain.Entidades;

namespace Kanban.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<QuadroDTO, Quadro>()
                .ConstructUsing(q => new Quadro(q.Titulo, q.Conteudo, q.Lista));
     
        }

    }
}
