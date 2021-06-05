using Desafio.Domain.Entities;
using Desafio.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infra.Data
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
       
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<TipoTransacao> TipoTransacoes { get; set; }
        public DbSet<TransacaoItem> TransacaosItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<TipoTransacao>().HasData(
                new TipoTransacao() { TipoTransacaoId = 1, Descricao = "Débito", Natureza = "Entrada", Sinal = "+" },
                new TipoTransacao() { TipoTransacaoId = 2, Descricao = "Boleto", Natureza = "Saída", Sinal = "-" },
                new TipoTransacao() { TipoTransacaoId = 3, Descricao = "Financiamento", Natureza = "Saída", Sinal = "-" },
                new TipoTransacao() { TipoTransacaoId = 4, Descricao = "Crédito", Natureza = "Entrada", Sinal = "+" },
                new TipoTransacao() { TipoTransacaoId = 5, Descricao = "Recebimento Empréstimo", Natureza = "Entrada", Sinal = "+" },
                new TipoTransacao() { TipoTransacaoId = 6, Descricao = "Vendas", Natureza = "Entrada", Sinal = "+" },
                new TipoTransacao() { TipoTransacaoId = 7, Descricao = "Recebimento TED", Natureza = "Entrada", Sinal = "+" },
                new TipoTransacao() { TipoTransacaoId = 8, Descricao = "Recebimento DOC", Natureza = "Entrada", Sinal = "+" },
                new TipoTransacao() { TipoTransacaoId = 9, Descricao = "Aluguel", Natureza = "Saída", Sinal = "-" }

                );
           
            modelBuilder.Entity<Loja>().ToTable("Loja");
            modelBuilder.Entity<TipoTransacao>().ToTable("TipoTransacao");
            modelBuilder.Entity<TransacaoItem>().ToTable("TransacaoItem");

            modelBuilder.ApplyConfiguration(new LojaMap());
            modelBuilder.ApplyConfiguration(new TipoTransacaoMap());
            modelBuilder.ApplyConfiguration(new TransacaoItemMap());
        }
    }
}
