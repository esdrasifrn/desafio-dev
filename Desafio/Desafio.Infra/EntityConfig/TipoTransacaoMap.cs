using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infra.EntityConfig
{
    public class TipoTransacaoMap : IEntityTypeConfiguration<TipoTransacao>
    {
        public void Configure(EntityTypeBuilder<TipoTransacao> builder)
        {
            builder.HasKey(c => c.TipoTransacaoId);

            builder
            .Property(a => a.Descricao).HasColumnName("Descricao")
            .HasColumnType("varchar(50)");

            builder
          .Property(a => a.Natureza).HasColumnName("Natureza")
          .HasColumnType("varchar(50)");

            builder
         .Property(a => a.Sinal).HasColumnName("Sinal")
         .HasColumnType("char(1)");
        }
    }
}
