using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.Entities
{
    public class Loja
    {
        private IList<TransacaoItem> _transacaoItens;
        public int LojaId { get; set; }
        public string Dono { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<TransacaoItem> TransacaoItens { get => _transacaoItens; set { } }

        public Loja(string dono, string nome)
        {
            Dono = dono;
            Nome = nome;
            _transacaoItens = new List<TransacaoItem>();
        }

        public Loja()
        {

        }

        public void AddTransacaoItem(TransacaoItem transacao)
        {
            _transacaoItens.Add(transacao);
        }
    }
}
