using Kanban.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Infa.Data.Mapping
{
    public class QuadroMapping : IEntityTypeConfiguration<Quadro>
    {
        public void Configure(EntityTypeBuilder<Quadro> builder)
        {
            builder.HasKey(c => new { c.Id });
            builder.Ignore(c => c.ListaErros);
            builder.Ignore(c => c.ValidationResult);
            builder.Property(c => c.Titulo).HasMaxLength(50);
            builder.Property(c => c.Conteudo).HasMaxLength(4000);
            builder.Property(c => c.Lista).HasMaxLength(5);
            builder.ToTable("Quadros");
        }
    }
}
