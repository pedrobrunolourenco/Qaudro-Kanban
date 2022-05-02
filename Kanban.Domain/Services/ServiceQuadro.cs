using Kanban.Domain.Entidades;
using Kanban.Domain.Intefaces;
using System;
using System.Collections.Generic;

namespace Kanban.Domain.Services
{
    public class ServiceQuadro : IServiceQuadro
    {

        private readonly IRepositoryQuadro repo;

        public ServiceQuadro(IRepositoryQuadro _repo)
        {
            repo = _repo;
        }

        public IEnumerable<Quadro> ObterListaDeQuadros()
        {
            return repo.Listar();
        }

        public Quadro ObterPorId(Guid id)
        {
            return repo.ObterPorId(id);
        }

        public Quadro IncluirQuadro(Quadro quadro)
        {
            if (!quadro.EhValido()) return quadro;
            repo.Adicionar(quadro);
            repo.Salvar();
            return quadro;
        }

        public Quadro AlterarQuadro(Quadro quadro)
        {
            if (!quadro.EhValido()) return quadro;
            repo.DetachAllEntities();
            repo.Atualizar(quadro);
            repo.Salvar();
            return quadro;
        }

        public Quadro ExcluirQuadro(Guid id)
        {
            var quadro = repo.ObterPorId(id);
            repo.Remover(quadro);
            repo.Salvar();
            return quadro;
        }

    }
}
