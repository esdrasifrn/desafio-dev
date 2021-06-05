using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infra.EntityConfig
{
    public class LojaMap : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.HasKey(c => c.LojaId);
            builder
              .Property(l => l.LojaId).UseIdentityColumn();

            builder
               .HasMany(c => c.TransacaoItens)
               .WithOne(ci => ci.Loja);

            builder
             .Property(a => a.Dono).HasColumnName("Dono")
             .HasColumnType("varchar(50)");

            builder
            .Property(a => a.Nome).HasColumnName("Nome")
            .HasColumnType("varchar(50)");
        }
    }
}
