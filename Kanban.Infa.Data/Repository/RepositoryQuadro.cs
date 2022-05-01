using Kanban.Domain.Entidades;
using Kanban.Domain.Intefaces;
using Kanban.Infa.Data.Contextos;

namespace Kanban.Infa.Data.Repository
{
    public class RepositoryQuadro : RepositoryBase<Quadro>, IRepositoryQuadro
    {

        public RepositoryQuadro(ContextEF context) : base(context)
        {

        }

    }
}
