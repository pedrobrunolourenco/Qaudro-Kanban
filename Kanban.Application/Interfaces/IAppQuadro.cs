using Kanban.Application.DTOs;
using System;
using System.Collections.Generic;

namespace Kanban.Application.Interfaces
{
    public interface IAppQuadro
    {
        IEnumerable<QuadroDTO> ObterListaDeQuadros();
        QuadroDTO ObterPorId(Guid id);
        QuadroDTO IncluirQuadro(QuadroDTO quadro);
        QuadroDTO AlterarQuadro(QuadroDTO quadro);
        QuadroDTO ExcluirQuadro(Guid id);

    }
}
