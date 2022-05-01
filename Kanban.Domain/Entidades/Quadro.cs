using FluentValidation;
using Kanban.Domain.Enums;
using System;

namespace Kanban.Domain.Entidades
{
    public class Quadro : Entity
    {
        public Quadro()  {  }

        public Quadro(string titulo, string conteudo, string lista)
        {
            Titulo = titulo;
            Conteudo = conteudo;    
            Lista = lista;
        }

        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }
        public string Lista { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new QuadroValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }
    }


    public class QuadroValidation : AbstractValidator<Quadro>
    {
        public QuadroValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do quadro inválido");


            RuleFor(c => c.Titulo)
                .NotEmpty()
                .WithMessage("O título do quadro não foi informado");

            RuleFor(c => c.Titulo)
                .MaximumLength(50)
                .WithMessage("Título do quadro deve ter no máximo 50 caracteres");

            RuleFor(c => c.Conteudo)
                .NotEmpty()
                .WithMessage("O conteúdo do quadro não foi informado");

            RuleFor(c => c.Conteudo)
                .MaximumLength(4000)
                .WithMessage("O conteúdo do quadro deve ter no máximo 4000 caracteres");

            RuleFor(c => c.Lista)
                .NotEmpty()
                .WithMessage("A lista do quadro não foi informada");

            RuleFor(c => c.Lista)
                .Must(ValidaLista)
                .WithMessage("Lista do quadro não aceitável");
        }

        protected static bool ValidaLista(string lista)
        {
            return (lista == TipoLista.ToDo.ToString() || lista == TipoLista.Doing.ToString() || lista == TipoLista.Done.ToString()); ;
        }
    }
}
