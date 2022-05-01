using AutoMapper;
using Kanban.Application.DTOs;
using Kanban.Application.Interfaces;
using Kanban.Domain.Entidades;
using Kanban.Domain.Intefaces;
using System;
using System.Collections.Generic;

namespace Kanban.Application.Services
{
    public class AppQuadro : IAppQuadro
    {
        private readonly IMapper _mapper;
        private readonly IServiceQuadro _serviceQuadro;

        public AppQuadro(IMapper mapper,
                        IServiceQuadro serviceQuadro)
        {
            _mapper = mapper;
            _serviceQuadro = serviceQuadro;
        }

        public IEnumerable<QuadroDTO> ObterListaDeQuadros()
        {
            return _mapper.Map<IEnumerable<QuadroDTO>>(_serviceQuadro.ObterListaDeQuadros());
        }

        public QuadroDTO ObterPorId(Guid id)
        {
           return _mapper.Map<QuadroDTO>(_serviceQuadro.ObterPorId(id));
        }

        public QuadroDTO IncluirQuadro(QuadroDTO quadro)
        {
            return _mapper.Map<QuadroDTO>(_serviceQuadro.IncluirQuadro(_mapper.Map<Quadro>(quadro))) ;
        }

        public QuadroDTO AlterarQuadro(QuadroDTO quadro)
        {
            return _mapper.Map<QuadroDTO>(_serviceQuadro.AlterarQuadro(_mapper.Map<Quadro>(quadro)));
        }

        public QuadroDTO ExcluirQuadro(Guid id)
        {
            return _mapper.Map<QuadroDTO>(_serviceQuadro.ExcluirQuadro(id));
        }

    }
}
