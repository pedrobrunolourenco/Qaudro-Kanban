using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Kanban.Domain.Entidades
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            ListaErros = new List<string>();
        }
        public Guid Id { get; private set; }
        public List<string > ListaErros { get; set; }
        public ValidationResult ValidationResult { get; set; }



        public virtual bool EhValido()
        {
            return true;
        }
    }
}
