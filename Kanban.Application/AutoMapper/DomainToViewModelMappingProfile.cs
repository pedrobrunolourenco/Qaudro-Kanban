using AutoMapper;
using Kanban.Application.DTOs;
using Kanban.Domain.Entidades;

namespace Kanban.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Quadro, QuadroDTO>();
        }
    }
}
