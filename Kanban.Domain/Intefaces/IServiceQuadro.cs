using Kanban.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Kanban.Domain.Intefaces
{
    public interface IServiceQuadro
    {
        IEnumerable<Quadro> ObterListaDeQuadros();
        Quadro ObterPorId(Guid id);
        Quadro IncluirQuadro(Quadro quadro);
        Quadro AlterarQuadro(Quadro quadro);
        Quadro ExcluirQuadro(Guid id);

    }
}
