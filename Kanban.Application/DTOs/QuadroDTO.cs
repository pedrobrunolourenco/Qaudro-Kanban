using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Kanban.Application.DTOs
{
    public class QuadroDTO
    {
        public QuadroDTO()
        {
            Id = Guid.NewGuid();
            ListaErros = new List<string>();
        }

        [Key]
        [IgnoreDataMember]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Necessário informar título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Necessário informar conteúdo")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "Necessário informar Lista")]
        public string Lista { get; set; }

        [IgnoreDataMember] 
        public List<string> ListaErros { get; set; }

    }
}
