using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infra.EntityConfig
{
    public class TransacaoItemMap : IEntityTypeConfiguration<TransacaoItem>
    {
        public void Configure(EntityTypeBuilder<TransacaoItem> builder)
        {
            builder.HasKey(c => c.TransacaoId);
            builder
              .Property(l => l.TransacaoId).UseIdentityColumn();

            builder
               .HasOne(c => c.Loja)
               .WithMany(ci => ci.TransacaoItens);

            builder
             .HasOne(c => c.TipoTransacao)
             .WithMany(ci => ci.TransacaoItens);

            builder
               .Property(a => a.Valor).HasColumnName("Valor")
               .HasColumnType("Decimal(15,2)");

            builder
              .Property(a => a.CpfBeneficiario).HasColumnName("CpfBeneficiario")
              .HasColumnType("varchar(15)");

            builder
              .Property(a => a.Cartao).HasColumnName("Cartao")
              .HasColumnType("varchar(20)");
        }
    }
}
