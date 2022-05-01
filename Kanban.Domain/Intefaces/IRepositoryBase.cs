using Kanban.Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Kanban.Domain.Intefaces
{
    public interface IRepositoryBase<TEntidade> : IDisposable where TEntidade : Entity
    {
        IEnumerable<TEntidade> Listar();
        TEntidade ObterPorId(Guid id);
        void Adicionar(TEntidade obj);
        void Atualizar(TEntidade obj);
        void Remover(TEntidade obj);
        void Salvar();
    }
}
